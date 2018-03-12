#pragma once

#include "stdafx.h"

#include <External/zstd.h>

namespace Katarina
{
	namespace Hooks
	{
		namespace LeagueClient
		{
			std::shared_ptr<spdlog::logger> logger;

			extern "C"
			{
				decltype(&ZSTD_decompress) orig_ZSTD_decompress = nullptr;

				int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize);
			}
		}
	}
}