#pragma once

#include "stdafx.h"

#include <filesystem>
#include <map>
#include <memory>
#include <vector>

#include "json/json.h"
#include "LuxHook.h"
#include "LuxKeybind.h"

#define LUX_ADDHOOK(mod, func) LuxApp::AddHook(L##mod, #func, &hk_##func, (LPVOID*)&orig_##func)

namespace fs = std::experimental::filesystem;

namespace Lux
{
	class LuxApp
	{
	public:
		//LuxApp();
		//~LuxApp();

		virtual HRESULT Initialize(LPCWSTR szExePath);
		virtual HRESULT Uninitialize();
		virtual HRESULT Render();
		virtual void RegisterKeybinds();
		virtual void RegisterHooks() {}

		HRESULT AddHook(LPCWSTR pszModule, LPCSTR pszProcName, LPVOID pDetour, LPVOID* ppOriginal);
		void EnableHooks();
		//void DisableHooks();

		void AddKeybind(std::string id, std::string displayName, int vk);
		void PrintKeybinds();

		HRESULT LoadConfig();

	protected:
		fs::path exePath;
		fs::path luxAppPath;
		fs::path configPath;
		fs::path dumpPath;

	private:
		std::vector<std::unique_ptr<Keybind>> m_Keybinds;
		std::vector<std::unique_ptr<Hook>> m_Hooks;
	};
}
