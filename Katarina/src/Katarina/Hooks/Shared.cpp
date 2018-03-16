#include "stdafx.h"

#include <Katarina/Hooks/Shared.h>

#include <hexprint.h>

namespace Katarina
{
	namespace Shared
	{
		namespace Hooks
		{
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
				}
			}
		}
	}
}
