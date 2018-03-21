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
			namespace KAT_HookNamespaceName(SSL_read)
			{
				extern std::shared_ptr<Katarina::ApiHook> apiHook;
				extern std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_read)(SSL *ssl, void *buf, int num);

					void KAT_FeatureHookName(SSL_read, print)(SSL *ssl, void *buf, int num);
				}
			}

			namespace KAT_HookNamespaceName(SSL_write)
			{
				extern std::shared_ptr<Katarina::ApiHook> apiHook;
				extern std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_write)(SSL *ssl, const void *buf, int num);

					void KAT_FeatureHookName(SSL_write, print)(SSL *ssl, const void *buf, int num);
					void KAT_FeatureHookName(SSL_write, print_api_events)(SSL *ssl, const void *buf, int num);
				}
			}

			namespace KAT_HookNamespaceName(SSL_CTX_ctrl)
			{
				extern std::shared_ptr<Katarina::ApiHook> apiHook;
				extern std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_CTX_ctrl)(SSL_CTX *ctx, int cmd, long larg, void *parg);

					void KAT_FeatureHookName(SSL_CTX_ctrl, print)(SSL_CTX *ctx, int cmd, long larg, void *parg);
				}
			}

			namespace KAT_HookNamespaceName(SSL_get_error)
			{
				extern std::shared_ptr<Katarina::ApiHook> apiHook;
				extern std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_get_error)(const SSL *ssl, int ret);

					void KAT_FeatureHookName(SSL_get_error, print)(const SSL *ssl, int ret);
				}
			}
		}
	}
}
