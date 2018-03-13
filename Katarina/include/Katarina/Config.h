#pragma once

#include "stdafx.h"

#include "json.hpp"

using nlohmann::json;

namespace Katarina
{
	namespace Config
	{
		struct Hook
		{
			std::string Identifier;
			bool Enabled;
			bool Verbose;
		};

		struct Keybinding
		{
			std::string Identifier;
			bool Enabled;
			int Keycode;
		};

		struct Keybindings
		{
			std::vector<struct Keybinding> Console;
			std::vector<struct Keybinding> Always;
		};

		struct Config
		{
			std::vector<struct Hook> Hooks;
			Keybindings Keybinds;
		};

		inline void to_json(json& j, const Hook& p)
		{
			j = json { { "identifier", p.Identifier }, { "enabled", p.Enabled }, { "verbose", p.Verbose } };
		}

		inline void from_json(const json& j, Hook& p)
		{
			p.Identifier = j.at("identifier").get<std::string>();
			p.Enabled = j.at("enabled").get<bool>();
			p.Verbose = j.at("verbose").get<bool>();
		}

		inline void to_json(json& j, const Keybinding& p)
		{
			j = json { { "identifier", p.Identifier }, { "enabled", p.Enabled }, { "keycode", p.Keycode } };
		}

		inline void from_json(const json& j, Keybinding& p)
		{
			p.Identifier = j.at("identifier").get<std::string>();
			p.Enabled = j.at("enabled").get<bool>();
			p.Keycode = j.at("keycode").get<int>();
		}

		inline void to_json(json& j, const Keybindings& p)
		{
			j = json { { "console", p.Console }, { "always", p.Always } };
		}

		inline void from_json(const json& j, Keybindings& p)
		{
			p.Console = j.at("console").get<std::vector<struct Keybinding>>();
			p.Always = j.at("always").get<std::vector<struct Keybinding>>();
		}

		inline void to_json(json& j, const Config& p)
		{
			j = json { { "hooks", p.Hooks }, { "keybinds", p.Keybinds } };
		}

		inline void from_json(const json& j, Config& p)
		{
			p.Hooks = j.at("hooks").get<std::vector<struct Hook>>();
			p.Keybinds = j.at("keybinds").get<Keybindings>();
		}
	}
}