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
		return EnabledFeatureHooks.size() > 0;
	}

	void ApiHook::AddFeatureHook(FeatureHook featureHook)
	{
		AllFeatureHooks.insert(featureHook);
	}

	void ApiHook::EnableFeatureHook(const FeatureHook* featureHook)
	{
		EnabledFeatureHooks[featureHook->Order].insert(featureHook);
	}

	void ApiHook::DisableFeatureHook(const FeatureHook* featureHook)
	{
		EnabledFeatureHooks[featureHook->Order].erase(featureHook);
	}
}
