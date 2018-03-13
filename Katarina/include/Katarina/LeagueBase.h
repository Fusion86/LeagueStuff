#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/Hook.h>

#define KAT_AddApiHook(mod, func) apiHook_##func = LeagueBase::AddApiHook(mod, #func, &hk_##func)

#define KAT_AddFeatureHook(func, name, order) \
	apiHook_##func->AddFeatureHook(FeatureHook { false, #name, hk_##func##$##name }, HookOrder::AfterOriginal);

namespace Katarina
{
	class LeagueBase
	{
	public:
		virtual const char* GetExecutableName() = 0;

	protected:
		fs::path m_appPath;
		fs::path m_configPath;

		Config::Config m_config;

		std::set<std::shared_ptr<ApiHook>> m_hooks;

	private:
		std::atomic<bool> m_shutdownRequested = false;
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt("LeagueBase");

	public:
		virtual HRESULT Initialize();
		virtual HRESULT Uninitialize();

		void Run();
		void Shutdown() { m_shutdownRequested = true; }
		
	protected:
		std::shared_ptr<ApiHook> AddApiHook(std::string module, std::string procName, LPVOID pDetour);

		virtual void RegisterHooks() = 0;
		virtual void RegisterKeybindings();
	};
}