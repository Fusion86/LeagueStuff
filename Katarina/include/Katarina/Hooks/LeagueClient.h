#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>
#include <Katarina/Hook.h>
#include <Katarina/VoidTracker.h>
#include <External/curl.h>
#include <External/zstd.h>

#include <memdmp.h>
#include <hexprint.h>

namespace Katarina
{
	namespace LeagueClient
	{
		namespace Hooks
		{
			fs::path dumpPath;
			VoidTracker curl_handles;
			SOCKET serverSocket = NULL;

#pragma region CURL

			namespace KAT_HookNamespaceName(curl_easy_setopt)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					CURLcode KAT_HookName(curl_easy_setopt)(CURL *handle, CURLoption option, void* parameter)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&curl_easy_setopt)(hook->Target))(handle, option, parameter);

						CURLcode res = (decltype(&curl_easy_setopt)(apiHook->Original))(handle, option, parameter);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&curl_easy_setopt)(hook->Target))(handle, option, parameter);

						return res;
					}

					void KAT_FeatureHookName(curl_easy_setopt, print)(CURL *handle, CURLoption option, void* parameter)
					{
						const char* optStr = curlopt_to_str(option);
						int handleNumber = curl_handles.Get(handle);

						if (_curl_is_string_option(option))
							logger->info("[Handle {}] Set option '{}' to '{}'", handleNumber, optStr, (char*)parameter);
						else
							logger->info("[Handle {}] Set option '{}' to '{}'", handleNumber, optStr, (int)parameter);
					}
				}
			}

			namespace KAT_HookNamespaceName(curl_multi_perform)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					CURLMcode KAT_HookName(curl_multi_perform)(CURLM *multi_handle, int *running_handles)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&curl_multi_perform)(hook->Target))(multi_handle, running_handles);

						CURLMcode res = (decltype(&curl_multi_perform)(apiHook->Original))(multi_handle, running_handles);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&curl_multi_perform)(hook->Target))(multi_handle, running_handles);

						return res;
					}

					void KAT_FeatureHookName(curl_multi_perform, print)(CURLM *multi_handle, int *running_handles)
					{
						logger->info("{}", (int)multi_handle); // This is just boilerplate stuff, not usefull for anything
					}
				}
			}

#pragma endregion

#pragma region Ws2_32

			namespace KAT_HookNamespaceName(bind)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int __stdcall KAT_HookName(bind)(SOCKET s, const struct sockaddr* name, int namelen)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&bind)(hook->Target))(s, name, namelen);

						int res = (decltype(&bind)(apiHook->Original))(s, name, namelen);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&bind)(hook->Target))(s, name, namelen);

						return res;
					}

					void __stdcall KAT_FeatureHookName(bind, print)(SOCKET s, const struct sockaddr* name, int namelen)
					{
						// The first socket to be bound is the serverSocket;
						if (serverSocket == NULL)
							serverSocket = s;

						struct sockaddr_in sin;
						int addrlen = sizeof(sin);
						if (getsockname(s, (struct sockaddr *)&sin, &addrlen) == 0 &&
							sin.sin_family == AF_INET &&
							addrlen == sizeof(sin))
						{
							int local_port = ntohs(sin.sin_port);
							logger->info("Bind to port {}", local_port);
						}
					}
				}
			}

			namespace KAT_HookNamespaceName(recv)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int __stdcall KAT_HookName(recv)(SOCKET s, char* buf, int len, int flags)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&recv)(hook->Target))(s, buf, len, flags);

						int res = (decltype(&recv)(apiHook->Original))(s, buf, len, flags);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&recv)(hook->Target))(s, buf, len, flags);

						return res;
					}

					void __stdcall KAT_FeatureHookName(recv, print)(SOCKET s, char* buf, int len, int flags)
					{
						if (GetAsyncKeyState(VK_F2))
							hexprint("recv", buf, len);
					}
				}
			}

#pragma endregion

#pragma region ZSTD

			namespace KAT_HookNamespaceName(ZSTD_decompress)
			{
				std::shared_ptr<Katarina::ApiHook> apiHook;
				std::shared_ptr<spdlog::logger> logger;

				extern "C"
				{
					int KAT_HookName(ZSTD_decompress)(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
					{
						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::BeforeOriginal])
							(decltype(&ZSTD_decompress)(hook->Target))(dst, dstCapacity, src, compressedSize);

						int res = (decltype(&ZSTD_decompress)(apiHook->Original))(dst, dstCapacity, src, compressedSize);

						for (const auto& hook : apiHook->EnabledFeatureHooks[Katarina::HookOrder::AfterOriginal])
							(decltype(&ZSTD_decompress)(hook->Target))(dst, dstCapacity, src, compressedSize);

						return res;
					}

					void KAT_FeatureHookName(ZSTD_decompress, dump)(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
					{
						fs::path path = dumpPath;
						path /= "ZSTD_decompress--" + Utils::GetDateTimeString() + ".bin";

						memdmp(path.string().c_str(), dst, dstCapacity);

						logger->info("Dumped to '{}'", path);
					}

					void KAT_FeatureHookName(ZSTD_decompress, hello)(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
					{
						logger->info("Hello!");
					}
				}
			}

#pragma endregion

		}
	}
}
