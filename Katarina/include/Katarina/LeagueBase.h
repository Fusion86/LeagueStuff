#pragma once

#include "stdafx.h"

#include <Katarina/Config.h>
#include <Katarina/ApiHook.h>
#include <Katarina/FeatureHook.h>

//#define KAT_AddApiHook(mod, func) ApiHook& func = LeagueBase::AddApiHook(mod, #func, &hk_##func, (LPVOID*)&orig_##func)

//#define KAT_AddFeatureHook(func, order, callback) LeagueBase::AddFeatureHook(func, order, callback);
//#define KAT_AddFeatureHook(func, name, order) LeagueBase::AddFeatureHook(func, #name, order, func##___##name)

//#define KAT_UseFeatureHooks(name) \
//	typedef decltype(&##name) functype; \
//	std::vector<LPCVOID>* beforeHooks = nullptr; \
//	std::vector<LPCVOID>* afterHooks = nullptr; \
//\
//	auto const& featureHooks = g_featureHooks->find((LPCVOID)orig_##name); \
//	if (true) \
//	{ \
//		beforeHooks = &featureHooks->second[Katarina::HookOrder::BeforeOriginal]; \
//		afterHooks = &featureHooks->second[Katarina::HookOrder::AfterOriginal]; \
//	}
//
//#define KAT_ExecuteFeatureHooks(hooks, ...) \
//	if (hooks != nullptr) \
//	{ \
//		for (auto& hook : *hooks) \
//		{ \
//			if (hook == NULL) \
//			{ \
//				g_logger->error("FeatureHook points to NULL"); \
//			} \
//			else \
//			{ \
//				functype ptr = (functype)hook; \
//				ptr(__VA_ARGS__); \
//			} \
//		} \
//	}

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
		
		std::vector<std::shared_ptr<ApiHook>> m_apiHooks;
		std::vector<std::shared_ptr<FeatureHook>> m_featureHooks;

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
		HRESULT AddFeatureHook(ApiHook& apiHook, std::string name, HookOrder order, LPCVOID callback);

		virtual void RegisterHooks() = 0;
		virtual void RegisterKeybindings();
	};
}