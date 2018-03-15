#pragma once

#include "stdafx.h"

#define KAT_HookNamespaceName(func) ns_##func
#define KAT_HookName(func) hk_##func
#define KAT_FeatureHookName(func, name) hk_##func##$##name

#define KAT_RegisterApiHook(mod, func) \
	Hooks::KAT_HookNamespaceName(func)::logger = spdlog::stdout_color_mt(#func); \
	Hooks::KAT_HookNamespaceName(func)::apiHook = LeagueBase::AddApiHook(mod, #func, &Hooks::KAT_HookNamespaceName(func)::KAT_HookName(func))

#define KAT_RegisterFeatureHook(func, name, order) \
	Hooks::KAT_HookNamespaceName(func)::apiHook->AddFeatureHook(FeatureHook { #name, Hooks::KAT_HookNamespaceName(func)::KAT_FeatureHookName(func, name), order });

#define KAT_RegisterSharedApiHook(mod, func) \
	Shared::Hooks::KAT_HookNamespaceName(func)::logger = spdlog::stdout_color_mt(#func); \
	Shared::Hooks::KAT_HookNamespaceName(func)::apiHook = LeagueBase::AddApiHook(mod, #func, &Shared::Hooks::KAT_HookNamespaceName(func)::KAT_HookName(func))

#define KAT_RegisterSharedFeatureHook(func, name, order) \
	Shared::Hooks::KAT_HookNamespaceName(func)::apiHook->AddFeatureHook(FeatureHook { #name, Shared::Hooks::KAT_HookNamespaceName(func)::KAT_FeatureHookName(func, name), order });


namespace Katarina
{
	enum HookOrder
	{
		BeforeOriginal,
		AfterOriginal
	};

	struct FeatureHook
	{
		std::string Name;
		LPCVOID Target;
		HookOrder Order;

		bool operator < (const FeatureHook& other) const {
			return Target < other.Target;
		}
	};

	class ApiHook
	{
	public:
		std::string Module;
		std::string ProcName;
		LPVOID Detour;
		LPVOID Original;
		LPVOID Target;

		std::set<FeatureHook> AllFeatureHooks; // Do NOT edit this set yourself, as that might result in invalid pointers in EnabledFeatureHooks (I think)

		// We use a different set to keep track of the enabled hooks because this is (probably) faster than doing a `if (hook.IsEnabled)` ***foreach hook every time*** the parent apiHook is called
		std::map<HookOrder, std::set<const FeatureHook*>> EnabledFeatureHooks; // Does it make sense to use smart pointers here? I think not, probably?

	private:

	public:
		std::string GetIdentifier();

		std::string GetFeatureHookIdentifier(FeatureHook featureHook);

		bool GetIsNeeded();

		void AddFeatureHook(FeatureHook featureHook);
		void EnableFeatureHook(const FeatureHook* featureHook);
		void DisableFeatureHook(const FeatureHook* featureHook);
	};
}
