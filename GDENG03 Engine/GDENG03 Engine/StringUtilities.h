#pragma once
#include<iostream>
#include<sstream>
#include<string>
#include<vector>

class StringUtilities
{
public:
	static std::vector<std::string> split(const std::string& long_string, char delim_char);
	static void deleteCharacter(std::string* string, char char_to_remove);
};