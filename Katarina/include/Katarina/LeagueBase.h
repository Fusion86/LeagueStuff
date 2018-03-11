#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/ApiHook.h>

#define KAT_AddApiHook(mod, func) LeagueBase::AddApiHook(mod, #func, &hk_##func, (LPVOID*)&orig_##func)

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
		
		std::vector<std::unique_ptr<ApiHook>> apiHooks;
		std::vector<int> featureHooks;

	private:
		std::atomic<bool> shutdownRequested = false;
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt("LeagueBase");

	public:
		virtual HRESULT Initialize();
		virtual HRESULT Uninitialize();

		void Run();
		void Shutdown() { shutdownRequested = true; }
		
	protected:
		HRESULT AddApiHook(std::string module, std::string procName, LPVOID pDetour, LPVOID *ppOriginal);
		HRESULT AddFeatureHook();

		virtual void RegisterApiHooks() = 0;
		virtual void RegisterFeatureHooks() = 0;
		virtual void RegisterKeybindings();
	};
}