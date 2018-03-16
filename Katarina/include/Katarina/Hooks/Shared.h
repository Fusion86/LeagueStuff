#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>
#include <External/openssl.h>

namespace Katarina
{
	namespace Shared
	{
		namespace Hooks
		{
			namespace KAT_HookNamespaceName(SSL_write)
			{
				extern std::shared_ptr<Katarina::ApiHook> apiHook;
				extern std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_write)(SSL *ssl, const void *buf, int num);

					void KAT_FeatureHookName(SSL_write, print)(SSL *ssl, const void *buf, int num);
				}
			}
		}
	}
}
