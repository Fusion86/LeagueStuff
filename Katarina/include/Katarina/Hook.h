#pragma once

#include "stdafx.h"

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
