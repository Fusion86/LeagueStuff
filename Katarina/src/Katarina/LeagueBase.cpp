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
		m_appPath /= GetName();
		logger->info("App Path: {}", m_appPath);
		fs::create_directories(m_appPath);

		m_configPath.assign(m_appPath);
		m_configPath /= "Config.json";
		logger->info("Config Path: {}", m_configPath);
		fs::create_directories(m_configPath.parent_path());

		m_dumpPath = m_appPath;
		m_dumpPath /= "Dump";
		fs::create_directories(m_dumpPath);

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

		for (const auto& apiHook : m_hooks)
		{
			logger->debug("ApiHook: {}", apiHook->GetIdentifier());

			for (const auto& featureHook : apiHook->AllFeatureHooks)
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
					logger->info("FeatureHook '{}' is not defined in the config file. Adding it with the default values", identifier);

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
						logger->info("Found FeatureHook '{}' in config, enabling it", identifier);
						apiHook->EnableFeatureHook(&featureHook);
					}
					else
					{
						logger->info("Found FeatureHook '{}' in config, but it is disabled", identifier);
						// No need to disable it, since it is disabled by default
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
		// Enable hooks
		for (const auto& apiHook : m_hooks)
		{
			if (apiHook->GetIsNeeded())
			{
				int res = MH_EnableHook(apiHook->Target);
				if (res == MH_OK)
				{
					logger->info("Enabled ApiHook '{}'", apiHook->GetIdentifier());
				}
				else
				{
					logger->error("Couldn't enable ApiHook. Reason: {}", MH_StatusToString((MH_STATUS)res));
				}
			}
			else
			{
				logger->debug("No need to enable ApiHook '{}' as no FeatureHooks use it", apiHook->GetIdentifier());
			}
		}

		int oldTime = 0;
		int newTime = 0; // If an Update() ever takes so long that the int will overflow then the int overflow is the least of our worries
		LARGE_INTEGER now;
		LARGE_INTEGER frequency;
		bool use_qpc = QueryPerformanceFrequency(&frequency);

		if (!use_qpc)
			logger->warn("We can't use QueryPerformanceFrequency, but I am not sure if that matters.");

		// Update loop
		while (!m_shutdownRequested)
		{
			oldTime = newTime;
			QueryPerformanceCounter(&now);
			newTime = (1000LL * now.QuadPart) / frequency.QuadPart;

			if (GetAsyncKeyState(VK_F3))
				Shutdown();

			Update(newTime - oldTime); // This will usually be equal to m_updateInterval, but I guess it is nice to have in somecases

			Sleep(m_updateInterval); // No need to 'catch up' (m_updateInterval - (delta - m_updateInterval)) when the delta time is larger than expected, worst case scenario is that nothing happens for a split second
		}

		// Disable hooks (maybe?)
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
			m_hooks.insert(hook);
		}
		else
		{
			logger->warn("Failed to hook '{}' in '{}'. Reason: {}", hook->ProcName, hook->Module, MH_StatusToString((MH_STATUS)res));
		}

		return hook;
	}

	void LeagueBase::Update(int delta)
	{
		// Print delta time if deviation is larger than 5%
		if (abs(delta - m_updateInterval) > m_updateInterval * 0.05)
			logger->debug("Delta time: {}ms", delta);
	}

	void LeagueBase::RegisterKeybindings()
	{

	}
}
