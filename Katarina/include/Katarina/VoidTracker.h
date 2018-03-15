#pragma once

#include "stdafx.h"

namespace Katarina
{
	// Use this class to keep track of void pointers and print them in a easy to read/compare way
	// Get() could return a number that was ***previously*** associated with another object,
	// but by that time the prev object will no longer exist. So I guess that doesn't matter.
	class VoidTracker
	{
	private:
		int i = 0;
		std::map<void*, int> map;

	public:
		inline int Get(void* ptr)
		{
			auto it = map.find(ptr);
			if (it != map.end())
				return it->second;
			else
				return map[ptr] = ++i;
		}
	};
}
