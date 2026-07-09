#include <stdio.h>
#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>

enum lineType { all=0, individual=1 };

const char* applyFunction(auto& value) {
	//TODO
	printf("calling applyFunction ...\n");
	return ""; //empty string (result) for the moment
}

void readCSV
(
	const std::string& filePath, 
	const char splitChar, 
	const lineType lnType, 
	const short int column
) {
	std::ifstream file(filePath);

	if (!file.is_open()) {
		std::cerr << "Error: Could not open the file!" << std::endl;
		return;
	}

	std::string line;

	std::vector<std::vector<std::string>> rows;

	while (std::getline(file, line)) {
		std::stringstream lineStream(line);
		std::string cell;
		std::vector<std::string> row;

		while (std::getline(lineStream, cell, splitChar)) {
			row.push_back(cell);
		}

		rows.push_back(row);

		std::cout << std::endl;
	}

	printf("Print each value from every line of csv file.\n\n");

	int numline = 1;

	for (const auto& row : rows) {
		if (row.size()) {
			printf("line: %d\n", numline);
			short int col = 0;

			for (const auto& value : row) {
				col ++;

				std::cout << "value: " << value << std::endl;

				if (lnType == lineType::individual && col == column) {

					std::cout << "applying function for \"" << value << "\" ..." << std::endl;
					applyFunction(value);

				}
			}

			printf("\n");
			numline ++;
		}
	}

	file.close();
}

int main() {
	const std::string filePath = "./source.csv";
	char splitChar = ' ';
	short int column = 2;
	lineType lnIndividual = lineType::individual;

	readCSV(filePath, splitChar, lnIndividual, column);

	return 1;
}
