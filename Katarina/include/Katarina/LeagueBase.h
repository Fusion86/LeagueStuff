#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/ApiHook.h>
#include <Katarina/FeatureHook.h>

//#define KAT_PrepareHook(func) \
//	decltype(&##func) orig_##func;
//	//std::map<Katarina::HookOrder, std::vector<decltype(&##func)>> fhk_##func;
//
//#define KAT_AddApiHook(mod, func) ApiHook& apiHook_##func = LeagueBase::AddApiHook(mod, #func, &hk_##func, (LPVOID*)&orig_##func)
//
//#define KAT_AddFeatureHook(func, name, order) \
//	/*FeatureHook& featureHook_##func = */LeagueBase::AddFeatureHook(apiHook_##func, #name, order, func##___##name);
//	//fhk_##func[order].push_back((decltype(&##func))featureHook_##func.FeatureFunction);

namespace Katarina
{
	enum HookOrder
	{
		BeforeOriginal,
		AfterOriginal
	};

	class LeagueBase
	{
	public:
		virtual const char* GetExecutableName() = 0;

	protected:
		fs::path m_appPath;
		fs::path m_configPath;

		Config::Config m_config;

		std::map<std::string, std::shared_ptr<ApiHook>> m_apiHooks;
		std::map<std::string, std::shared_ptr<FeatureHook>> m_featureHooks;

	private:
		std::atomic<bool> m_shutdownRequested = false;
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt("LeagueBase");

	public:
		virtual HRESULT Initialize();
		virtual HRESULT Uninitialize();

		void Run();
		void Shutdown() { m_shutdownRequested = true; }
		
	protected:
		ApiHook& AddApiHook(std::string module, std::string procName, LPVOID pDetour, _Out_ LPVOID *ppOriginal);
		FeatureHook& AddFeatureHook(ApiHook& apiHook, std::string name, HookOrder order, LPCVOID callback);

		virtual void RegisterHooks() = 0;
		virtual void RegisterKeybindings();
	};
}