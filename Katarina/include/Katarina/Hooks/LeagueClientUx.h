#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>
#include <Katarina/Hook.h>
#include <External/cef.h>

namespace Katarina
{
	namespace LeagueClientUx
	{
		namespace Hooks
		{
			fs::path dumpPath;

			namespace KAT_HookNamespaceName(cef_parse_url)
			{
				static std::shared_ptr<Katarina::ApiHook> apiHook;
				static std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(cef_parse_url)(const cef_string_t* url, cef_urlparts_t* parts)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&cef_parse_url)(hook->Target))(url, parts);

						int res = (decltype(&cef_parse_url)(apiHook->Original))(url, parts);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&cef_parse_url)(hook->Target))(url, parts);

						return res;
					}

					void KAT_FeatureHookName(cef_parse_url, log)(const cef_string_t* url, cef_urlparts_t* parts)
					{
						logger->info(L"{}", url->str);
					}
				}
			}
		}
	}
}
