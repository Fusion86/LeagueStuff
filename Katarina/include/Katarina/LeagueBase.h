#pragma once

#include "stdafx.h"

namespace Katarina
{
	class LeagueBase
	{
	public:
		virtual const char* GetExecutableName() = 0;

	protected:
		fs::path appPath;
		fs::path configPath;
		
		std::vector<int> apiHooks;
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
		virtual void RegisterApiHooks() = 0;
		virtual void RegisterFeatureHooks() = 0;
	};
}