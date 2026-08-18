// ----------------------------------------

#include <fstream>
#include <string>
#include <iostream>
#include <stdio.h>
#include <fstream>
#include <cstring>
#include <sstream>
#include <vector>

// ----------------------------------------

std::vector<std::string> split(const std::string &str, char delim) {
	std::vector<std::string> tokens;
	std::string token;
	std::stringstream ss(str);

	while (getline(ss, token, delim)) {
		tokens.push_back(token);
	}

	return tokens;
}

// ----------------------------------------


// ----------------------------------------

int main(int argc, char** argv) {


    // ----------------------------------------

    std::ofstream outputFile("readMarket.cpp");

    // ----------------------------------------


    // ----------------------------------------
    // characters configuration - BEGIN

    char slash = 47; // "/" slash
    char quote = 34; // '"' quote

    char tab = 9; // tab
    char newline = 10; // new line
    char verticaltab = 11; // vertical tab
    char formfeed = 12; // form feed
    char creturn = 13; // carriage return

    // characters configuration - END
    // ----------------------------------------


    // ----------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // ----------------------------------------


    // ----------------------------------------
    // parameters from command line - BEGIN

    int amount_tensor = 0; // amount of tensors
    char delimiter = 0; // delimiter character
    char* pathFile = 0; // path input-file

    std::string text = argv[1];
    std::vector<std::string> result = split(text, '=');

    if (result[0].compare("--amount") == 0) {
	amount_tensor = std::stoi(result[1]);
    }

    text = argv[2];
    result = split(text, '=');

    if (result[0].compare("--delimiter") == 0) {
  	delimiter = result[1].front();
    }

    text = argv[3];
    result = split(text, '=');

    if (result[0].compare("--pathFile") == 0) {
	char charArr[result[1].length() + 1];

	std::copy(result[1].begin(), result[1].end(), charArr);
	charArr[result[1].length()] = '\0';

	pathFile = (char*) malloc(result[1].length() + 1);

	strcpy(pathFile, charArr);
    }

    if (amount_tensor == 0 || delimiter == 0 || strlen(pathFile) == 0) {
        std::cerr << "Error: No all parameters were specified." << std::endl;
        return 1;
    }

    // parameters from command line - END
    // ----------------------------------------


    // ----------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // ----------------------------------------


    // ----------------------------------------

    if (!outputFile.is_open()) {
        std::cerr << "Error: Could not create or open the file." << std::endl;
        return 1;
    }

    // ----------------------------------------

    // ----------------------------------------
    // libraries - BEGIN

    outputFile << "#include <stdio.h>" << std::endl;
    outputFile << std::endl;

    // ----------------------------------------

    outputFile << "#include <torch/torch.h>" << std::endl;
    outputFile << "#include <torch/script.h>" << std::endl;
    outputFile << std::endl;

    // ----------------------------------------

    outputFile << "#include <iostream>" << std::endl;
    outputFile << "#include <fstream>" << std::endl;
    outputFile << "#include <sstream>" << std::endl;
    outputFile << "#include <vector>" << std::endl;
    outputFile << "#include <tuple>" << std::endl;
    outputFile << "#include <string>" << std::endl;
    outputFile << "#include <cstring>" << std::endl;
    outputFile << "#include <memory>" << std::endl;
    outputFile << "#include <typeinfo>" << std::endl;
    outputFile << "#include <cxxabi.h>" << std::endl;
    outputFile << "#include <stdexcept>" << std::endl;
    outputFile << "#include <array>" << std::endl;
    outputFile << "#include <unistd.h>" << std::endl;
    outputFile << "#include <sys/wait.h>" << std::endl;
    outputFile << std::endl;

    // ----------------------------------------

    outputFile << "#include <filesystem>" << std::endl;
    outputFile << "#include <boost/filesystem.hpp>" << std::endl;
    outputFile << std::endl;

    // ----------------------------------------

    outputFile << "#include <iomanip>" << std::endl;
    outputFile << "#include <ctime>" << std::endl;
    outputFile << std::endl;

    // libraries - END
    // ----------------------------------------


    // ----------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // ----------------------------------------


    // ----------------------------------------
    // function trim - BEGIN

    outputFile << "std::string trim(const std::string& str) {" << std::endl;

    outputFile << "    size_t start = str.find_first_not_of("
		<< quote
		//<< tab << newline << verticaltab << formfeed << creturn
		<< "\\t\\n\\v\\f\\r"
		<< quote
		<< ");"
		<< std::endl;

    outputFile << "    size_t end = str.find_last_not_of("
		<< quote
		//<< tab << newline << verticaltab << formfeed << creturn
		<< "\\t\\n\\v\\f\\r"
		<< quote
		<< ");"
		<< std::endl;

    outputFile << std::endl;
    outputFile << "    if (start == std::string::npos) {" << std::endl;
    outputFile << "            return " << quote << quote << ";" << std::endl;
    outputFile << "    }" << std::endl;
    outputFile << std::endl;
    outputFile << "    return str.substr(start, end - start + 1);" << std::endl;
    outputFile << "}" << std::endl;

    // function trim - END
    // ----------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // ----------------------------------------
    // function testConvertFloat - BEGIN

    outputFile << "bool testConvertFloat(std::string value) {" << std::endl;
    outputFile << "        bool result;" << std::endl;
    outputFile << std::endl;
    outputFile << "        try {" << std::endl;
    outputFile << "                float val = std::stof(value);" << std::endl;
    outputFile << "                result = true;" << std::endl;
    outputFile << "        }" << std::endl;
    outputFile << "        catch (const std::exception& e) {" << std::endl;
    outputFile << "                result = false;" << std::endl;
    outputFile << "        }" << std::endl;
    outputFile << std::endl;
    outputFile << "        return result;" << std::endl;
    outputFile << "}" << std::endl;

    // function testConvertFloat - END
    // ----------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // ----------------------------------------
    // function testConvertDate - BEGIN

    outputFile << "bool testConvertDate(std::string value) {" << std::endl;
    // ----
    outputFile << "        bool result = false;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "        try {" << std::endl;
    // ----
    outputFile << "                std::tm tm = {};" << std::endl;
    outputFile << "                std::istringstream ss(value);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "                ss >> std::get_time(&tm, " << quote << "%m/%d/%y" << quote << ");" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "                if (ss.fail()) {" << std::endl;
    outputFile << "                        result = false;" << std::endl;
    outputFile << "                } else {" << std::endl;
    outputFile << "                        try {" << std::endl;
    outputFile << "                                std::time_t date_t = std::mktime(&tm);" << std::endl;
    outputFile << "                                result = true;" << std::endl;
    outputFile << "                        }" << std::endl;
    outputFile << "                        catch (const std::exception& e) {" << std::endl;
    outputFile << "                                result = false;" << std::endl;
    outputFile << "                        }" << std::endl;
    outputFile << "                }" << std::endl;
    // ----
    outputFile << "        }" << std::endl;
    // ----
    outputFile << "        catch (const std::exception& e) {" << std::endl;
    outputFile << "                result = false;" << std::endl;
    outputFile << "        }" << std::endl;
    // ----
    outputFile << std::endl;
    // ----
    outputFile << "        return result;" << std::endl;
    outputFile << "}" << std::endl;

    // function testConvertDate - END
    // ----------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // ----------------------------------------
    // function exec - BEGIN

    outputFile << "std::string exec(const char* cmd) {" << std::endl;
    outputFile << "     std::array<char, 128> buffer;" << std::endl;
    outputFile << "     std::string result;" << std::endl;
    outputFile << std::endl;
    outputFile << "    #pragma GCC diagnostic push" << std::endl;
    outputFile << "    #pragma GCC diagnostic ignored \"-Wignored-attributes\"" << std::endl;
    outputFile << "    std::unique_ptr<FILE, decltype(&pclose)> pipe(popen(cmd, \"r\"), pclose);" << std::endl;
    outputFile << "    #pragma GCC diagnostic pop" << std::endl;
    outputFile << std::endl;
    outputFile << std::endl;
    outputFile << "    if (!pipe) {" << std::endl;
    outputFile << "             throw std::runtime_error(\"popen() failed.\");" << std::endl;
    outputFile << "    }" << std::endl;
    outputFile << std::endl;
    outputFile << "     while (fgets(buffer.data(), static_cast<int>(buffer.size()), pipe.get()) != nullptr) {" << std::endl;
    outputFile << "             result += buffer.data();" << std::endl;
    outputFile << "     }" << std::endl;
    outputFile << std::endl;
    outputFile << "     return result;" << std::endl;
    outputFile << "}" << std::endl;

    // function exec - END
    // --------------------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // --------------------------------------------------
    // struct CustomModel - BEGIN

    outputFile << "struct CustomModel : torch::nn::Module {" << std::endl;
    // ----
    outputFile << "     torch::nn::Linear fc1{nullptr};" << std::endl;
    outputFile << "     torch::nn::Linear fc2{nullptr};" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     CustomModel(" << std::endl;
    outputFile << "             int64_t input_size," << std::endl;
    outputFile << "             int64_t hidden_size," << std::endl;
    outputFile << "             int64_t output_size" << std::endl;
    outputFile << "     ) {" << std::endl;
    outputFile << "             fc1 = register_module(\"fc1\", torch::nn::Linear(input_size, hidden_size));" << std::endl;
    outputFile << "             fc2 = register_module(\"fc2\", torch::nn::Linear(hidden_size, output_size));" << std::endl;
    outputFile << "     }" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     torch::Tensor forward(torch::Tensor x) {" << std::endl;
    outputFile << "             x = x.to(torch::kFloat32);" << std::endl;
    outputFile << std::endl;
    outputFile << "             x = x.reshape(x.sizes());" << std::endl;
    outputFile << std::endl;
    outputFile << "             x = torch::relu(fc1->forward(x));" << std::endl;
    outputFile << "             x = fc2->forward(x);" << std::endl;
    outputFile << std::endl;
    outputFile << "             return x;" << std::endl;
    outputFile << "     }" << std::endl;
    // ----
    outputFile << "};" << std::endl;

    // struct CustomModel - END
    // --------------------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // --------------------------------------------------
    // function getModel - BEGIN

    outputFile << "CustomModel getModel(" << std::endl;
    outputFile << "     std::vector<std::vector<std::tuple<std::string, float, float, float, float, float, float>>> values," << std::endl;  
    outputFile << "     const int amountAmountTensor" << std::endl;
    outputFile << ") {" << std::endl;
    // ----
    outputFile << "     CustomModel model(" << std::endl;
    outputFile << "             amountAmountTensor, " << slash << slash << " amount rows-fixed" << std::endl;
    outputFile << "             1, " << slash << slash << " 1 row-fixed" << std::endl;
    outputFile << "             1 " << slash << slash << " 1 depth" << std::endl;
    outputFile << "     );" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::vector<float> open_column;" << std::endl;
    outputFile << "     std::vector<float> close_column;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     float open_value = 0.0;" << std::endl;
    outputFile << "     float close_value = 0.0;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::vector<std::tuple<std::string, float, float, float, float, float, float>>::iterator g;" << std::endl;
    outputFile << std::endl;
    outputFile << "     torch::Tensor input_tensor;" << std::endl;
    outputFile << "     torch::Tensor input;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "	for (int x = 0; x < values.size(); x ++) {" << std::endl;
    outputFile << "		g = values[x].begin();" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "		open_value = std::get<1>(*g);" << std::endl;
    outputFile << "		close_value = std::get<4>(*g);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "		open_column.push_back(open_value);" << std::endl;
    outputFile << "		close_column.push_back(close_value);" << std::endl;
    // ----
    outputFile << "	}" << std::endl;
    outputFile << std::endl;


    // ----

    outputFile << std::endl;
    outputFile << std::endl;

    // ----


    // ---- ----------- ----
    // tensor::open_column - BEGIN

    // ----
    outputFile << "	input_tensor = torch::tensor(" << std::endl;
    outputFile << "		{" << std::endl;

    for (int index = 0; index < amount_tensor; index ++) {
        if (index + 1 == amount_tensor) {

    outputFile << "			open_column[" << index << "]" << std::endl;

        } else {

    outputFile << "			open_column[" << index << "]," << std::endl;

        }
    }

    outputFile << "		}," << std::endl;
    outputFile << "		torch::kFloat32" << std::endl;
    outputFile << "	);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << " open column" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << "  << std::endl;" << std::endl;
    outputFile << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << input_tensor << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     input = model.forward(input_tensor);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << " << quote  << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << input << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    // ----
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----

    // tensor::open_column - END
    // ---- ----------- ----


    // ----

    outputFile << std::endl;
    outputFile << std::endl;

    // ----


    // ---- ----------- ----
    // tensor::close_column - BEGIN

    // ----
    outputFile << "	input_tensor = torch::tensor(" << std::endl;
    outputFile << "		{" << std::endl;

    for (int index = 0; index < amount_tensor; index ++) {
        if ((index + 1) == amount_tensor) {

    outputFile << "			close_column[" << index << "]" << std::endl;

        } else {

    outputFile << "			close_column[" << index << "]," << std::endl;

        }
    }

    outputFile << "		}," << std::endl;
    outputFile << "		torch::kFloat32" << std::endl;
    outputFile << "	);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << " close column \" << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << input_tensor << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;

    // tensor::close_column - END
    // ---- ----------- ----

    outputFile << "     input = model.forward(input_tensor);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    outputFile << "     std::cout << input << std::endl;" << std::endl;
    outputFile << "     std::cout << " << quote << slash << slash << "--------------------------" << quote << " << std::endl;" << std::endl;
    // ----

    outputFile << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     return model;" << std::endl;
    // ----
    outputFile << "}" << std::endl;

    // function getModel - END
    // --------------------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // --------------------------------------------------
    // function readCSV - BEGIN

    outputFile << "CustomModel readCSV" << std::endl;
    outputFile << "(" << std::endl;
    outputFile << "     const std::string& pathFile," << std::endl;
    outputFile << "     const char chrSplit," << std::endl;
    outputFile << "     const int amountAmountTensor" << std::endl;
    outputFile << ") {" << std::endl;
    // ----
    outputFile << "CustomModel model(1, 1, 1);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "int numLines = 0;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "std::ifstream in(pathFile);" << std::endl;
    outputFile << "std::string unused;" << std::endl;
    // ----
    outputFile << std::endl;
    outputFile << "while ( std::getline(in, unused) )" << std::endl;
    outputFile << "     ++ numLines;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "-- numLines;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "std::ifstream file(pathFile);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "if (!file.is_open()) {" << std::endl;
    outputFile << "     std::cerr << " << quote <<  "Error: Could not open the file." << quote << " << std::endl;" << std::endl;
    outputFile << "     return model;" << std::endl;
    outputFile << "}" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "std::string line;" << std::endl;
    outputFile << std::endl;
    outputFile << "std::vector<std::vector<std::string>> rows;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "int config_rows = numLines; " << slash << slash << " last empty lines should not be counted" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "int config_cols = 6;" << std::endl;
    outputFile << "int config_all_cols = 7;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "int num_col = 0;" << std::endl;
    outputFile << "int num_row = 0;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "std::vector<std::vector<float>> values(config_rows, std::vector<float>(config_cols, 0.0f));" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "while (std::getline(file, line)) {" << std::endl;
    outputFile << "     std::stringstream lineStream(line);" << std::endl;
    outputFile << "     std::string cell;" << std::endl;
    outputFile << "     std::vector<std::string> row;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     num_row ++;" << std::endl;
    outputFile << "     num_col = 0;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     bool valid = true;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     while" << std::endl;
    outputFile << "     (" << std::endl;
    outputFile << "             std::getline(lineStream, cell, chrSplit)" << std::endl;
    outputFile << "     )" << std::endl;
    outputFile << "     {" << std::endl;
    outputFile << "                num_col ++;" << std::endl;
    outputFile << std::endl;
    outputFile << "                if (num_row == 1) {" << std::endl;
    outputFile << "                        continue;" << std::endl;
    outputFile << "                }" << std::endl;
    outputFile << std::endl;
    outputFile << "                if (num_col == 1) {" << std::endl;
    outputFile << "                        if  (!testConvertDate(cell)) {" << std::endl;
    outputFile << "                                valid = false;" << std::endl;
    outputFile << "                        }" << std::endl;
    outputFile << "                } else {" << std::endl;
    outputFile << "                        if  (!testConvertFloat(cell)) {" << std::endl;
    outputFile << "                                valid = false;" << std::endl;
    outputFile << "                        }" << std::endl;
    outputFile << "                }" << std::endl;
    outputFile << std::endl;
    outputFile << "                if (valid) {" << std::endl;
    outputFile << "                        row.push_back(cell);" << std::endl;
    outputFile << "                }" << std::endl;
    outputFile << "        }" << std::endl;
    outputFile << std::endl;
    outputFile << "        std::cout << std::endl;" << std::endl;
    outputFile << "        std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    outputFile << "        if ((valid) && (row.size() == config_all_cols)) {" << std::endl;
    outputFile << "                rows.push_back(row);" << std::endl;
    outputFile << "        }" << std::endl;
    outputFile << "}" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     std::vector<std::vector<std::tuple<std::string, float, float, float, float, float, float>>> myArr;" << std::endl;
    outputFile << "     std::vector<std::tuple<std::string, float, float, float, float, float, float>> rowArr;" << std::endl;
    outputFile << std::endl;
    outputFile << "	std::vector<std::vector<std::string>>::iterator itt_begin = rows.begin();" << std::endl;  // this was updated
    outputFile << "	std::vector<std::vector<std::string>>::iterator itt_end = rows.end();" << std::endl;  // this was updated
    outputFile << "	std::vector<std::vector<std::string>>::iterator itt = itt_begin;" << std::endl;  // this was updated
    outputFile << std::endl;
    // ----
    outputFile << "	std::string date_str;" << std::endl;
    outputFile << "	float value_ft_open;" << std::endl;
    outputFile << "	float value_ft_high;" << std::endl;
    outputFile << "	float value_ft_low;" << std::endl;
    outputFile << "	float value_ft_close;" << std::endl;
    outputFile << "	float value_ft_adj_close;" << std::endl;
    outputFile << "	float value_ft_volume;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "	int rowline = 0;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "	for (const auto& row : rows) {" << std::endl;
    outputFile << "		rowline ++;" << std::endl;
    outputFile << std::endl;
    outputFile << "		if (row.size() == config_all_cols) {" << std::endl;
    // ----
    outputFile << "		try {" << std::endl;
    outputFile << "			auto it = (*itt).begin();" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		it = (*itt).begin();" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		date_str = *it;" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		value_ft_open = std::stof(*it);" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		value_ft_high = std::stof(*it);" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		value_ft_low = std::stof(*it);" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		value_ft_close = std::stof(*it);" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		value_ft_adj_close = std::stof(*it);" << std::endl;
    outputFile << "	     		++ it;" << std::endl;
    outputFile << std::endl;
    outputFile << "	    		value_ft_volume = std::stof(*it);" << std::endl;
    outputFile << std::endl;
    outputFile << "	    		rowArr.push_back(" << std::endl;
    outputFile << "	             		std::make_tuple(" << std::endl;
    outputFile << "	                     		date_str," << std::endl;
    outputFile << "	                     		value_ft_open," << std::endl;
    outputFile << "	                     		value_ft_high," << std::endl;
    outputFile << "	                     		value_ft_low," << std::endl;
    outputFile << "	                     		value_ft_close," << std::endl;
    outputFile << "	                     		value_ft_adj_close," << std::endl;
    outputFile << "	                     		value_ft_volume" << std::endl;
    outputFile << "	             		)" << std::endl;
    outputFile << "	     		);" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		myArr.push_back(rowArr);" << std::endl;
    outputFile << std::endl;
    outputFile << "	     		rowArr.erase(" << std::endl;
    outputFile << "	            		rowArr.begin()," << std::endl;
    outputFile << "	             		rowArr.end()" << std::endl;
    outputFile << "	     		);" << std::endl;
    outputFile << "		}" << std::endl;
    // ----
    outputFile << "		catch (const std::exception& e) {" << std::endl;
    outputFile << "	     		continue;" << std::endl;
    outputFile << "		}" << std::endl;
    // ----
    outputFile << "	}" << std::endl;
    // ----
    outputFile << "}" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "	std::cout << std::endl;" << std::endl;
    outputFile << "	std::cout << std::endl;" << std::endl;
    // ----
    outputFile << "	file.close();" << std::endl;
    // ----
    outputFile << std::endl;
    outputFile << "	return getModel(" << std::endl;
    outputFile << "		myArr," << std::endl;
    outputFile << "		amountAmountTensor" << std::endl;
    outputFile << "	);" << std::endl;
    // ----
    outputFile << "}" << std::endl;

    // function readCSV - END
    // --------------------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // --------------------------------------------------
    // function main - BEGIN

    outputFile << "int main(int argc, char *argv[]) {" << std::endl;
    // ----
    outputFile << "     const std::string paramPathFile = " << quote << pathFile << quote << ";" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     const char paramDelimiter = '" << delimiter << "';" << std::endl;
    outputFile << "     const int paramAmountTensor = " << amount_tensor << ";" << std::endl;
    outputFile << std::endl;
    outputFile << "     std::cout << std::endl;" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     CustomModel model = readCSV(paramPathFile, paramDelimiter, paramAmountTensor);" << std::endl;
    outputFile << std::endl;
    // ----
    outputFile << "     return 0;" << std::endl;
    outputFile << "}" << std::endl;

    // function main - END
    // --------------------------------------------------


    // --------------------------------------------------

    outputFile << std::endl;
    outputFile << std::endl;

    // --------------------------------------------------


    // ----------------------------------------

    outputFile.close();

    // ----------------------------------------


    // ----------------------------------------
    // final result - BEGIN

    std::cout << "File generated." << std::endl;

    // final result - END
    // ----------------------------------------


    // ----------------------------------------

    return 0;

    // ----------------------------------------


}
