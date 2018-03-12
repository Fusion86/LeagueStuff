#pragma once

namespace Katarina
{
	struct FeatureHook
	{
		ApiHook ApiHook;
		std::string Name;
		int HookOrder;
		LPCVOID FeatureFunction;

		inline std::string GetIdentifier()
		{
			return ApiHook.GetIdentifier() + "-" + Name;
		}
	};
}