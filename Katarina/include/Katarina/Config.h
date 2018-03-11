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
			std::string identifier;
			bool enabled;
			bool verbose;
		};

		struct Keybinding
		{
			std::string identifier;
			bool enabled;
			int keycode;
		};

		struct Keybindings
		{
			std::vector<struct Keybinding> console;
			std::vector<struct Keybinding> always;
		};

		struct Config
		{
			std::vector<struct Hook> hooks;
			Keybindings keybinds;
		};

		inline void to_json(json& j, const Hook& p) {
			j = json { { "identifier", p.identifier }, { "enabled", p.enabled }, { "keycode", p.verbose } };
		}

		inline void from_json(const json& j, Hook& p) {
			p.identifier = j.at("identifier").get<std::string>();
			p.enabled = j.at("enabled").get<bool>();
			p.verbose = j.at("age").get<bool>();
		}

		inline void to_json(json& j, const Keybinding& p) {
			j = json { { "identifier", p.identifier }, { "enabled", p.enabled }, { "keycode", p.keycode } };
		}

		inline void from_json(const json& j, Keybinding& p) {
			p.identifier = j.at("identifier").get<std::string>();
			p.enabled = j.at("enabled").get<bool>();
			p.keycode = j.at("age").get<int>();
		}

		inline void to_json(json& j, const Keybindings& p) {
			j = json { { "console", p.console }, { "always", p.always } };
		}

		inline void from_json(const json& j, Keybindings& p) {
			p.console = j.at("console").get<std::vector<struct Keybinding>>();
			p.always = j.at("always").get<std::vector<struct Keybinding>>();
		}

		inline void to_json(json& j, const Config& p) {
			j = json { { "hooks", p.hooks }, { "keybinds", p.keybinds } };
		}

		inline void from_json(const json& j, Config& p) {
			p.hooks = j.at("hooks").get<std::vector<struct Hook>>();
			p.keybinds = j.at("keybinds").get<Keybindings>();
		}
	}
}