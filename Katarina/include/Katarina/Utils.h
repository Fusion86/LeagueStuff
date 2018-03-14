#pragma once

#include "stdafx.h"

namespace Katarina
{
	namespace Utils
	{
		inline std::string GetDateTimeString()
		{
			SYSTEMTIME st;
			GetLocalTime(&st);

			std::stringstream ss;
			ss << st.wYear << "-" << st.wMonth << "-" << st.wDay
				<< "--" << st.wHour << "-" << st.wMinute << "-" << st.wSecond << "-" << st.wMilliseconds;

			return ss.str();
		}
	}
}