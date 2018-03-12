#include "stdafx.h"

#include <Katarina/Hooks/LeagueClient.h>

extern "C"
{
	int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);

		return res;
	}
}
