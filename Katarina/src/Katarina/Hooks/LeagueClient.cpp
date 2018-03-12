#include "stdafx.h"

#include <Katarina/Hooks/LeagueClient.h>

namespace Katarina
{
	namespace Hooks
	{
		namespace LeagueClient
		{
			extern "C"
			{
				int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
				{
					int res = 0;
					return res;
				}
			}
		}
	}
}