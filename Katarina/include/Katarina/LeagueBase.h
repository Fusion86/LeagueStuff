#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/Hook.h>

namespace Katarina
{
	class LeagueBase
	{
	public:
		virtual const char* GetName() { return "LeagueBase"; };

	protected:
		int m_updateInterval = 100; // Time between updates in milliseconds

		fs::path m_appPath;
		fs::path m_configPath;
		fs::path m_dumpPath;

		Config::Config m_config;

		std::set<std::shared_ptr<ApiHook>> m_hooks;

	private:
		std::atomic<bool> m_shutdownRequested = false;
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt(GetName());

	public:
		virtual HRESULT Initialize();
		virtual HRESULT Uninitialize();

		void Run();
		void Shutdown() { m_shutdownRequested = true; }

	protected:
		std::shared_ptr<ApiHook> AddApiHook(std::string module, std::string procName, LPVOID pDetour);

		virtual void Update(int delta);
		virtual void RegisterHooks() = 0;
		virtual void RegisterKeybindings();
	};
}
