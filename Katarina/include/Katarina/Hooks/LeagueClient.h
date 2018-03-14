#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>
#include <Katarina/Hook.h>
#include <External/zstd.h>

#include <memdmp.h>

namespace Katarina
{
	namespace LeagueClient
	{
		namespace Hooks
		{
			fs::path dumpPath;

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
						SYSTEMTIME st;
						GetLocalTime(&st);

						std::stringstream ss;
						ss << "luxdmp--" << st.wYear << "-" << st.wMonth << "-" << st.wDay
							<< "--" << st.wHour << "-" << st.wMinute << "-" << st.wSecond << "-" << st.wMilliseconds << ".bin";

						fs::path path = dumpPath;
						path /= ss.str();

						memdmp(path.string().c_str(), dst, dstCapacity);

						logger->info("Dumped to '{}'", path);
					}

					void KAT_FeatureHookName(ZSTD_decompress, hello)(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
					{
						logger->info("Hello!");
					}
				}
			}
		}
	}
}
