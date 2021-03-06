#pragma once

#define _CRT_SECURE_NO_WARNINGS
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <Shlwapi.h>

#include <filesystem>
#include <fstream>
#include <iostream>
#include <map>
#include <memory>
#include <set>
#include <sstream>
#include <vector>

#include "spdlog/spdlog.h"
#include "spdlog/fmt/bundled/ostream.h"

#include <Katarina/Utils.h>

namespace fs = std::experimental::filesystem;
