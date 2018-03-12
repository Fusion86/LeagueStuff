#pragma once

#include "stdafx.h"

namespace Katarina
{
	struct ApiHook
	{
		std::string Module;
		std::string ProcName;
		LPVOID Detour;
		LPVOID Original;
		LPVOID Target;
		bool IsNeeded;

		inline std::string GetIdentifier()
		{
			return Module + "-" + ProcName;
		}
	};
}
