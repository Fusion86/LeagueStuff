#pragma once

#include "stdafx.h"

namespace Lux
{
	typedef struct _Keybind
	{
		std::string Identifier;
		std::string DisplayName;
		int VirtualKey;
	} Keybind;
}