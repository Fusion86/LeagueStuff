#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>
#include <Katarina/Hook.h>
#include <Katarina/VoidTracker.h>
#include <External/curl.h>
#include <External/zstd.h>

#include <memdmp.h>

namespace Katarina
{
	namespace LeagueClient
	{
		namespace Hooks
		{
			fs::path dumpPath;
			VoidTracker curl_handles;

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

#pragma endregion

#pragma region ZSTD

			namespace KAT_HookNamespaceName(ZSTD_decompress)
			{
				static std::shared_ptr<Katarina::ApiHook> apiHook;
				static std::shared_ptr<spdlog::logger> logger;

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
