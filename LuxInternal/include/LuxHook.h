#pragma once

#include "stdafx.h"

namespace Lux
{
	typedef struct _Hook
	{
		bool WantEnabled = false;
		LPCWSTR Module;
		LPCSTR Function;
		LPVOID Detour;
		LPVOID Original;
		LPVOID Target;
	} Hook;
}