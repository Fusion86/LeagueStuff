#include "stdafx.h"

#include <Katarina/LeagueBase.h>

namespace Katarina
{
	HRESULT LeagueBase::Initialize()
	{
		const char* appdata = getenv("APPDATA");
		appPath.assign(appdata);
		appPath /= "Katarina";
		appPath /= GetExecutableName();
		logger->info("App Path: {}", appPath);

		configPath.assign(appPath);
		configPath /= "Config.json";
		logger->info("Config Path: {}", configPath);

		//std::ifstream in(configPath, std::ifstream::in);
		//std::ostringstream ss;
		//ss << in.rdbuf();

		//config = nlohmann::json::parse(ss.str());

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
}