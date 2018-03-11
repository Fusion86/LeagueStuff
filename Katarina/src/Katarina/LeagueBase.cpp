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

#pragma region Config

		RegisterApiHooks();
		RegisterFeatureHooks();

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

	//HRESULT LeagueBase::AddApiHook(std::string module, std::string procName, LPVOID pDetour, LPVOID *ppOriginal)
	//{
	//	std::unique_ptr<ApiHook> hook(new ApiHook {
	//			module,
	//			procName,
	//			pDetour,
	//			0,
	//			0
	//		});

	//	wchar_t szwModule[MAX_PATH + 1];
	//	mbstowcs(szwModule, module.c_str(), sizeof(szwModule));

	//	int res = MH_CreateHookApiEx(szwModule, hook->ProcName.c_str(), hook->Detour, ppOriginal, &hook->Target);

	//	if (res == MH_OK)
	//	{
	//		logger->info("Created {} hook {}", hook->Module, hook->ProcName);
	//		hook->Original = *ppOriginal;
	//		apiHooks.push_back(std::move(hook));
	//	}
	//	else
	//	{
	//		std::string reason(MH_StatusToString((MH_STATUS)res));
	//		logger->warn("Failed to create {} hook in {}. Reason:", hook->ProcName, hook->Module);
	//	}

	//	return 0;
	//}
}