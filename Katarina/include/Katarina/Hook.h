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
		bool IsEnabled;
		std::string Name;
		LPCVOID Target;
	};

	class ApiHook
	{
	public:
		std::string Module;
		std::string ProcName;
		LPVOID Detour;
		LPVOID Original;
		LPVOID Target;

		std::map<HookOrder, std::vector<FeatureHook>> FeatureHooks;

	public:
		std::string GetIdentifier() 
		{
			return Module + "-" + ProcName;
		}

		std::string GetFeatureHookIdentifier(FeatureHook featureHook)
		{
			return GetIdentifier() + "-" + featureHook.Name;
		}

		bool IsNeeded()
		{
			return false;
		}

		void AddFeatureHook(FeatureHook& featureHook, HookOrder hookOrder)
		{

		}
	};
}
