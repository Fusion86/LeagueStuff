#include "stdafx.h"

#include <Katarina/Hooks/Shared.h>

#include <hexprint.h>

namespace Katarina
{
	namespace Shared
	{
		namespace Hooks
		{
			namespace KAT_HookNamespaceName(SSL_read)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_read)(SSL *ssl, void *buf, int num)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&SSL_read)(hook->Target))(ssl, buf, num);

						int res = (decltype(&SSL_read)(apiHook->Original))(ssl, buf, num);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&SSL_read)(hook->Target))(ssl, buf, num);

						return res;
					}

					void KAT_FeatureHookName(SSL_read, print)(SSL *ssl, void *buf, int num)
					{
						if (GetAsyncKeyState(VK_F6))
							hexprint("SSL_read", buf, num > 0x50 ? 0x50 : num);
					}
				}
			}

			namespace KAT_HookNamespaceName(SSL_write)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;
				thread_local int res = NULL;

				extern "C"
				{
					int KAT_HookName(SSL_write)(SSL *ssl, const void *buf, int num)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&SSL_write)(hook->Target))(ssl, buf, num);

						res = (decltype(&SSL_write)(apiHook->Original))(ssl, buf, num);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&SSL_write)(hook->Target))(ssl, buf, num);

						return res;
					}

					void KAT_FeatureHookName(SSL_write, print)(SSL *ssl, const void *buf, int num)
					{
						std::string desc("SSL_write");
						desc += " res: " + std::to_string(res) + " num: " + std::to_string(num);

						if (GetAsyncKeyState(VK_F5))
							hexprint(desc.c_str(), buf, num > 0x50 ? 0x50 : num);
					}

					void KAT_FeatureHookName(SSL_write, print_api_events)(SSL *ssl, const void *buf, int num)
					{
						char aob[] = { 0x81, 0x7e, 0x00 };

						if (strncmp((char*)buf, (char*)aob, sizeof(aob)) == 0)
						{
							hexprint("print_api_events", buf, num);
						}
					}
				}
			}

			namespace KAT_HookNamespaceName(SSL_CTX_ctrl)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_CTX_ctrl)(SSL_CTX *ctx, int cmd, long larg, void *parg)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&SSL_CTX_ctrl)(hook->Target))(ctx, cmd, larg, parg);

						int res = (decltype(&SSL_CTX_ctrl)(apiHook->Original))(ctx, cmd, larg, parg);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&SSL_CTX_ctrl)(hook->Target))(ctx, cmd, larg, parg);

						return res;
					}

					void KAT_FeatureHookName(SSL_CTX_ctrl, print)(SSL_CTX *ctx, int cmd, long larg, void *parg)
					{
						logger->info("Set option '{}' to l: '{}' (p: '{}') in context '{}'", cmd, larg, (int)parg, (int)ctx);
					}
				}
			}

			namespace KAT_HookNamespaceName(SSL_get_error)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_get_error)(const SSL *ssl, int ret)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&SSL_get_error)(hook->Target))(ssl, ret);

						int res = (decltype(&SSL_get_error)(apiHook->Original))(ssl, ret);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&SSL_get_error)(hook->Target))(ssl, ret);

						return res;
					}

					void KAT_FeatureHookName(SSL_get_error, print)(const SSL *ssl, int ret)
					{
						if (ret != -1)
							logger->info("SSL: '{}' ret: '{}'", (int)ssl, ret);
					}
				}
			}
		}
	}
}
