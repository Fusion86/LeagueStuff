#include "stdafx.h"

#include <codecvt>
#include <fstream>
#include <iostream>
#include <sstream>
#include <string>

#include "MinHook.h"

#include "LuxApp.h"

namespace Lux
{
	LuxApp::LuxApp()
	{
	}

	LuxApp::~LuxApp()
	{
	}

	HRESULT LuxApp::Initialize(LPCWSTR szExePath)
	{
		int res = MH_Initialize();

		if (res == MH_OK)
			printf("[LuxApp Initialize] MinHook initialized!\n");
		else
		{
			printf("[LuxApp Initialize] MinHook couldn't be initialized! Error %s\n", MH_StatusToString((MH_STATUS)res));
			return res;
		}

		RegisterKeybinds();
		RegisterHooks();

		if (LoadConfig(szExePath) != 0)
		{
			printf("[LuxApp Initialize] Couldn't load config, using default values\n");
		}

		EnableHooks();

		return 0;
	}

	HRESULT LuxApp::Uninitialize()
	{
		int res = MH_Uninitialize();

		if (res == MH_OK)
			printf("[LuxApp Uninitialize] Ok!\n");
		else
			printf("[LuxApp Uninitialize] Error %s!\n", MH_StatusToString((MH_STATUS)res));

		return 0;
	}

	void LuxApp::RegisterKeybinds()
	{
		AddKeybind("console-clear", "Clear console", VK_F4);
		AddKeybind("unload", "Unload Lux", VK_F5);
	}

	HRESULT LuxApp::AddHook(LPCWSTR pszModule, LPCSTR pszProcName, LPVOID pDetour, LPVOID *ppOriginal)
	{
		std::unique_ptr<Hook> hook(new Hook {
			false,
			pszModule,
			pszProcName,
			pDetour,
			0,
			0
			});

		int res = MH_CreateHookApiEx(hook->Module, hook->Function, hook->Detour, ppOriginal, &hook->Target);

		if (res == MH_OK)
		{
			printf("[LuxApp AddHook] Created %s hook\n", hook->Function);
			hook->Original = *ppOriginal;
			m_Hooks.push_back(std::move(hook));
		}
		else
		{
			printf("[LuxApp AddHook] Failed to create %s hook, error %s\n", hook->Function, MH_StatusToString((MH_STATUS)res));
		}

		return res;
	}

	void LuxApp::EnableHooks()
	{
		for (auto& hook : m_Hooks)
		{
			if (hook->WantEnabled)
			{
				int res = MH_EnableHook(hook->Target);

				if (res == MH_OK)
					printf("[LuxApp EnableHooks] Hook %s enabled!\n", hook->Function);
				else
					printf("[LuxApp EnableHooks] Enabling hook %s returned error %s\n", hook->Function, MH_StatusToString((MH_STATUS)res));
			}
			else
			{
				printf("[LuxApp EnableHooks] Hook %s disabled in config\n", hook->Function);
			}
		}
	}

	void LuxApp::AddKeybind(std::string id, std::string displayName, int vk)
	{
		std::unique_ptr<Keybind> keybind(new Keybind {
			id,
			displayName,
			vk
			});

		m_Keybinds.push_back(std::move(keybind));
	}

	void LuxApp::PrintKeybinds()
	{
		std::string str = std::string(30, '*');

		printf("%s\n", str.c_str());
		printf("Keybinds:\n");

		for (auto &keybind : m_Keybinds)
		{
			printf("  %i - %s\n", keybind->VirtualKey, keybind->DisplayName.c_str());
		}

		printf("%s\n", str.c_str());
	}

	void LuxApp::InitializeConfig(Json::Value j)
	{
		for (auto &keybind : m_Keybinds)
		{
			j["keybinds"][keybind->Identifier] = keybind->VirtualKey;
		}

		for (auto &hook : m_Hooks)
		{
			j["hooks"][hook->Function] = hook->WantEnabled;
		}
	}

	HRESULT LuxApp::LoadConfig(LPCWSTR szExePath)
	{
		LPCWSTR rootDirName = L"League of Legends";
		std::wstring wsExePath(szExePath);

		int loc = wsExePath.find(rootDirName);
		if (loc == std::string::npos)
		{
			printf("[LuxApp LoadConfig] Root folder '%ls' folder not found!\n", rootDirName);
			return 1;
		}

		std::wstringstream wssConfigPath;
		wssConfigPath << wsExePath.substr(0, loc);
		wssConfigPath << rootDirName << "\\" << "Config" << "\\" << "Lux.json";

		std::wstring configPath = wssConfigPath.str();
		printf("[LuxApp LoadConfig] Config Path: %ls\n", configPath.c_str());

		Json::Value j;

		if (PathFileExists(configPath.c_str()))
		{
			std::ifstream ifs(configPath, std::ifstream::binary);

			Json::CharReaderBuilder rbuilder;
			std::string errs;
			bool ok = Json::parseFromStream(rbuilder, ifs, &j, &errs);

			if (!ok)
			{
				printf("[LuxApp LoadConfig] Json parsing failed!\n");
				printf("****\n %s \n****\n", errs.c_str());
				return 1;
			}
		}

		bool settingsChanged = false;

		// TODO: Make target specific (LeagueClient/LeagueClientUx)

		// Keybinds
		for (auto &keybind : m_Keybinds)
		{
			Json::Value* key = &j["keybinds"][keybind->Identifier];

			if (*key == Json::nullValue)
			{
				printf("[LuxApp LoadConfig] No value set for 'keybinds.%s', using the default value '%i'\n", keybind->Identifier.c_str(), keybind->VirtualKey);
				*key = keybind->VirtualKey;
				settingsChanged = true;
			}
			else
			{
				//printf("[LuxApp LoadConfig] Loaded \n");
				keybind->VirtualKey = key->asInt();
			}
		}

		// Hooks
		for (auto &hook : m_Hooks)
		{
			Json::Value* function = &j["hooks"][hook->Function];

			if (*function == Json::nullValue)
			{
				printf("[LuxApp LoadConfig] No value set for 'hooks.%s', using the default value '%s'\n", hook->Function, hook->WantEnabled ? "true" : "false");
				*function = hook->WantEnabled;
				settingsChanged = true;
			}
			else
			{
				//printf("[LuxApp LoadConfig] Loaded \n");
				hook->WantEnabled = function->asBool();
			}
		}

		if (settingsChanged)
		{
			Json::StreamWriterBuilder wbuilder;
			wbuilder["indentation"] = "    ";
			wbuilder["enableYAMLCompatibility"] = true;
			std::string doc = Json::writeString(wbuilder, j);
			printf("\nJSON:\n%s\n\n", doc.c_str());

			std::ofstream out(configPath);
			out << doc;
			out.close();
		}

		return 0;
	}
}
