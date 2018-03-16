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
							hexprint("SSL_read", buf, num);
					}
				}
			}

			namespace KAT_HookNamespaceName(SSL_write)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(SSL_write)(SSL *ssl, const void *buf, int num)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&SSL_write)(hook->Target))(ssl, buf, num);

						int res = (decltype(&SSL_write)(apiHook->Original))(ssl, buf, num);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&SSL_write)(hook->Target))(ssl, buf, num);

						return res;
					}

					void KAT_FeatureHookName(SSL_write, print)(SSL *ssl, const void *buf, int num)
					{
						if (GetAsyncKeyState(VK_F5))
							hexprint("SSL_write", buf, num);
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
		}
	}
}
