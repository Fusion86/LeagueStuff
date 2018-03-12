#include "stdafx.h"

#include <Katarina/LeagueBase.h>

#include <MinHook.h>

namespace Katarina
{
	HRESULT LeagueBase::Initialize()
	{
		const char* appdata = getenv("APPDATA");
		m_appPath.assign(appdata);
		m_appPath /= "Katarina";
		m_appPath /= GetExecutableName();
		logger->info("App Path: {}", m_appPath);
		fs::create_directories(m_appPath);

		m_configPath.assign(m_appPath);
		m_configPath /= "Config.json";
		logger->info("Config Path: {}", m_configPath);
		fs::create_directories(m_configPath.parent_path());

		int res = MH_Initialize();
		if (res == MH_OK)
		{
			logger->info("Initialized MinHook");
		}
		else
		{
			logger->error("Couldn't initialize MinHook. Reason: {}", MH_StatusToString((MH_STATUS)res));
			return res;
		}

		RegisterHooks();

#pragma region Config

		if (fs::exists(m_configPath))
		{
			logger->info("Found existing config file, loading it...");
			std::ifstream in(m_configPath);
			m_config = json::parse(in);
		}
		else
		{
			logger->info("No config file found, creating a new one...");
		}

		// Populate config
		for (auto const& featureHook : m_featureHooks)
		{
			bool found = false;
			for (auto const& hook : m_config.Hooks)
				if (hook.Identifier == featureHook.second->GetIdentifier())
				{
					found = true; break;
				}

			if (!found)
			{
				Config::Hook hook;
				hook.Identifier = featureHook.second->GetIdentifier();
				hook.Enabled = false;
				hook.Verbose = false;

				logger->critical("NOT FOUND!");

				m_config.Hooks.push_back(hook);
			}
		}

		json doc = m_config;
		std::ofstream out(m_configPath);
		out << doc;
		out.close();

#pragma endregion

		return 0;
	}

	HRESULT LeagueBase::Uninitialize()
	{
		int res = MH_Uninitialize();
		if (res == MH_OK)
		{
			logger->info("Uninitialized MinHook");
		}
		else
		{
			logger->error("Couldn't uninitialize MinHook. Reason: {}", MH_StatusToString((MH_STATUS)res));
			return res;
		}

		return 0;
	}

	void LeagueBase::Run()
	{
		while (!m_shutdownRequested)
		{
			if (GetAsyncKeyState(VK_DELETE))
				Shutdown();
		}
	}

	ApiHook& LeagueBase::AddApiHook(std::string module, std::string procName, LPVOID pDetour, _Out_ LPVOID *ppOriginal)
	{
		std::shared_ptr<ApiHook> hook(new ApiHook {
				module,
				procName,
				pDetour,
				0,
				0
			});

		wchar_t szwModule[MAX_PATH + 1];
		mbstowcs(szwModule, module.c_str(), sizeof(szwModule));

		int res = MH_CreateHookApiEx(szwModule, hook->ProcName.c_str(), hook->Detour, ppOriginal, &hook->Target);

		if (res == MH_OK)
		{
			logger->info("Hooked '{}' in '{}'", hook->ProcName, hook->Module);
			hook->Original = *ppOriginal;
			m_apiHooks[hook->GetIdentifier()] = hook;
		}
		else
		{
			logger->warn("Failed to hook '{}' in '{}'. Reason: {}", hook->ProcName, hook->Module, MH_StatusToString((MH_STATUS)res));
		}

		return *hook;
	}

	FeatureHook& LeagueBase::AddFeatureHook(ApiHook& apiHook, std::string name, HookOrder order, LPCVOID callback)
	{
		std::shared_ptr<FeatureHook> hook(new FeatureHook {
				apiHook,
				name,
				order,
				callback
			});

		logger->info("Registered feature hook '{}'", hook->GetIdentifier());

		m_featureHooks[hook->GetIdentifier()] = hook;

		return *hook;
	}

	void LeagueBase::RegisterKeybindings()
	{

	}
}