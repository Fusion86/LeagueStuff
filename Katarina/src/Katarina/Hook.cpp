#include "stdafx.h"

#include <Katarina/Hook.h>

namespace Katarina
{
	std::string ApiHook::GetIdentifier()
	{
		return Module + "-" + ProcName;
	}

	std::string ApiHook::GetFeatureHookIdentifier(FeatureHook featureHook)
	{
		return GetIdentifier() + "-" + featureHook.Name;
	}

	bool ApiHook::GetIsNeeded()
	{
		for (const auto& map : FeatureHooks)
			for (const auto& featureHook : map.second)
				if (featureHook.IsEnabled) return true;

		return false;
	}

	void ApiHook::AddFeatureHook(FeatureHook featureHook, HookOrder hookOrder)
	{
		FeatureHooks[hookOrder].insert(featureHook);
	}
}