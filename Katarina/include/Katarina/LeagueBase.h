#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/ApiHook.h>

#define KAT_AddApiHook(mod, func) ApiHook& func = LeagueBase::AddApiHook(mod, #func, &hk_##func, (LPVOID*)&orig_##func)

namespace Katarina
{
	class LeagueBase
	{
	public:
		virtual const char* GetExecutableName() = 0;

	protected:
		fs::path appPath;
		fs::path configPath;

		Config::Config config;
		
		std::vector<std::shared_ptr<ApiHook>> apiHooks;
		//std::map<LPVOID, LPVOID> featureHooks;

	private:
		std::atomic<bool> shutdownRequested = false;
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt("LeagueBase");

	public:
		virtual HRESULT Initialize();
		virtual HRESULT Uninitialize();

		void Run();
		void Shutdown() { shutdownRequested = true; }
		
	protected:
		ApiHook& AddApiHook(std::string module, std::string procName, LPVOID pDetour, _Out_ LPVOID *ppOriginal);
		HRESULT AddFeatureHook();

		virtual void RegisterHooks() = 0;
		virtual void RegisterKeybindings();
	};
}