#pragma once

#include "stdafx.h"

#include <map>
#include <memory>
#include <vector>

#include <json/json.h>

#include "LuxApp.h"
#include "LuxHook.h"
#include "LuxKeybind.h"

namespace Lux
{
	class LuxApp
	{
	public:
		LuxApp();
		~LuxApp();

		virtual HRESULT Initialize(LPCWSTR szExePath);
		virtual HRESULT Uninitialize();
		virtual HRESULT Render() = 0;
		virtual void RegisterKeybinds();
		virtual void RegisterHooks() = 0;

		HRESULT AddHook(LPCWSTR pszModule, LPCSTR pszProcName, LPVOID pDetour, LPVOID* ppOriginal);
		void EnableHooks();
		//void DisableHooks();

		void AddKeybind(std::string id, std::string displayName, int vk);
		void PrintKeybinds();

		void InitializeConfig(Json::Value j);
		HRESULT LoadConfig(LPCWSTR szExePath);

	private:
		std::vector<std::unique_ptr<Keybind>> m_Keybinds;
		std::vector<std::unique_ptr<Hook>> m_Hooks;
	};
}
