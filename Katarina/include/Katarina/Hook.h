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
		mutable bool IsEnabled;
		std::string Name;
		LPCVOID Target;

		bool operator<(const FeatureHook& other) const {
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

		std::map<HookOrder, std::set<FeatureHook>> FeatureHooks;
		std::map<HookOrder, std::set<int>> test;

	public:
		std::string GetIdentifier();

		std::string GetFeatureHookIdentifier(FeatureHook featureHook);

		bool GetIsNeeded();

		void AddFeatureHook(FeatureHook featureHook, HookOrder hookOrder);
	};
}
