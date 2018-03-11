#include "stdafx.h"

#include <Katarina/LeagueBase.h>

#include <MinHook.h>

namespace Katarina
{
	HRESULT LeagueBase::Initialize()
	{
		const char* appdata = getenv("APPDATA");
		appPath.assign(appdata);
		appPath /= "Katarina";
		appPath /= GetExecutableName();
		logger->info("App Path: {}", appPath);
		fs::create_directory(appPath);

		configPath.assign(appPath);
		configPath /= "Config.json";
		logger->info("Config Path: {}", configPath);
		fs::create_directory(configPath.parent_path());

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

#pragma region Config

		RegisterHooks();

		if (fs::exists(configPath))
		{
			logger->info("Found existing config file, loading it...");
			std::ifstream in(configPath);
			//json j = in;
			config = json::parse(in);
		}
		else
		{
			logger->info("No config file found, creating a new one...");
		}

		// Update config

		json doc = config;
		std::ofstream out(configPath);
		out << doc;
		out.close();

#pragma endregion

		return 0;
	}

	HRESULT LeagueBase::Uninitialize()
	{
		logger->info("Bye");

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
		while (!shutdownRequested)
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
			logger->info("Hooked {} in {}", hook->ProcName, hook->Module);
			hook->Original = *ppOriginal;
			apiHooks.push_back(hook);
		}
		else
		{
			logger->warn("Failed to hook {} in {}. Reason: {}", hook->ProcName, hook->Module, MH_StatusToString((MH_STATUS)res));
		}

		return *hook;
	}

	HRESULT LeagueBase::AddFeatureHook()
	{
		// Needed args
		// Ptr to orignal - its the key to the std::map which the ApiHook reads to find all FeatureHooks
		// Hook order - e.g before original is run or after
		// Priority - if there are multiple FeatureHooks
		// Ptr to FeatureHook - what method to execute

		return 0;
	}

	void LeagueBase::RegisterKeybindings()
	{

	}
}