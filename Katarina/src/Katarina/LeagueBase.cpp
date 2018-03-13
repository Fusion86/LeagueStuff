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

		json j;

		if (fs::exists(m_configPath))
		{
			logger->info("Found existing config file");
			std::ifstream in(m_configPath);
			m_config = json::parse(in);
		}
		else
		{
			logger->info("No config file found, creating a new one");
		}

		for (const auto& apiHook : m_Hooks)
		{
			logger->debug("ApiHook: {}", apiHook->GetIdentifier());

			for (auto& map : apiHook->FeatureHooks)
			{
				logger->debug("HookOrder: {}", map.first == HookOrder::BeforeOriginal ? "BeforeOriginal" : "AfterOriginal");

				for (auto& featureHook : map.second)
				{
					const Config::Hook* hook = nullptr;
					const std::string identifier = apiHook->GetFeatureHookIdentifier(featureHook);

					for (const auto& cfgHook : m_config.Hooks)
					{
						if (cfgHook.Identifier == identifier)
						{
							hook = &cfgHook;
							break;
						}
					}

					if (hook == nullptr)
					{
						logger->info("FeatureHook {} is not defined in the config file. Adding it with the default values");
						
						Config::Hook hook;
						hook.Identifier = identifier;
						hook.Enabled = false;
						hook.Verbose = false;

						m_config.Hooks.push_back(hook);
					}
					else
					{
						if (hook->Enabled)
						{
							logger->info("Found FeatureHook {} in config, enabling it", identifier);
							featureHook.IsEnabled = true;
						}
						else
						{
							logger->info("Found FeatureHook {} in config, but it is disabled", identifier);
						}
					}
				}
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

	std::shared_ptr<ApiHook> LeagueBase::AddApiHook(std::string module, std::string procName, LPVOID pDetour)
	{
		std::shared_ptr<ApiHook> hook(new ApiHook);
		hook->Module = module;
		hook->ProcName = procName;
		hook->Detour = pDetour;

		wchar_t szwModule[MAX_PATH + 1];
		mbstowcs(szwModule, module.c_str(), sizeof(szwModule));

		int res = MH_CreateHookApiEx(szwModule, hook->ProcName.c_str(), hook->Detour, &hook->Original, &hook->Target);

		if (res == MH_OK)
		{
			logger->info("Hooked '{}' in '{}'", hook->ProcName, hook->Module);
			m_Hooks.insert(hook);
		}
		else
		{
			logger->warn("Failed to hook '{}' in '{}'. Reason: {}", hook->ProcName, hook->Module, MH_StatusToString((MH_STATUS)res));
		}

		return hook;
	}

	//void LeagueBase::AddFeatureHook(ApiHook& apiHook, std::string name, HookOrder order, LPCVOID callback)
	//{
		//std::shared_ptr<FeatureHook> hook(new FeatureHook {
		//		apiHook,
		//		name,
		//		order,
		//		callback
		//	});

		//logger->info("Registered feature hook '{}'", hook->GetIdentifier());

		//m_featureHooks[hook->GetIdentifier()] = hook;

		//return *hook;
	//}

	void LeagueBase::RegisterKeybindings()
	{

	}
}