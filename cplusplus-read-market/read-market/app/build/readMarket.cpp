

#include <stdio.h>

#include <torch/torch.h>
#include <torch/script.h>

#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <tuple>
#include <string>
#include <cstring>
#include <memory>
#include <typeinfo>
#include <cxxabi.h>
#include <stdexcept>
#include <array>
#include <unistd.h>
#include <sys/wait.h>

#include <filesystem>
#include <boost/filesystem.hpp>

#include <iomanip>
#include <ctime>



std::string trim(const std::string& str) {
    size_t start = str.find_first_not_of("\t\n\v\f\r");
    size_t end = str.find_last_not_of("\t\n\v\f\r");

    if (start == std::string::npos) {
            return "";
    }

    return str.substr(start, end - start + 1);
}


bool testConvertFloat(std::string value) {
        bool result;

        try {
                float val = std::stof(value);
                result = true;
        }
        catch (const std::exception& e) {
                result = false;
        }

        return result;
}


bool testConvertDate(std::string value) {
        bool result = false;

        try {
                std::tm tm = {};
                std::istringstream ss(value);

                ss >> std::get_time(&tm, "%m/%d/%y");

                if (ss.fail()) {
                        result = false;
                } else {
                        try {
                                std::time_t date_t = std::mktime(&tm);
                                result = true;
                        }
                        catch (const std::exception& e) {
                                result = false;
                        }
                }
        }
        catch (const std::exception& e) {
                result = false;
        }

        return result;
}


std::string exec(const char* cmd) {
     std::array<char, 128> buffer;
     std::string result;

    #pragma GCC diagnostic push
    #pragma GCC diagnostic ignored "-Wignored-attributes"
    std::unique_ptr<FILE, decltype(&pclose)> pipe(popen(cmd, "r"), pclose);
    #pragma GCC diagnostic pop


    if (!pipe) {
             throw std::runtime_error("popen() failed.");
    }

     while (fgets(buffer.data(), static_cast<int>(buffer.size()), pipe.get()) != nullptr) {
             result += buffer.data();
     }

     return result;
}


struct CustomModel : torch::nn::Module {
     torch::nn::Linear fc1{nullptr};
     torch::nn::Linear fc2{nullptr};

     CustomModel(
             int64_t input_size,
             int64_t hidden_size,
             int64_t output_size
     ) {
             fc1 = register_module("fc1", torch::nn::Linear(input_size, hidden_size));
             fc2 = register_module("fc2", torch::nn::Linear(hidden_size, output_size));
     }

     torch::Tensor forward(torch::Tensor x) {
             x = x.to(torch::kFloat32);

             x = x.reshape(x.sizes());

             x = torch::relu(fc1->forward(x));
             x = fc2->forward(x);

             return x;
     }
};


CustomModel getModel(
     std::vector<std::vector<std::tuple<std::string, float, float, float, float, float, float>>> values,
     const int amountTensor
) {
     CustomModel model(
             53, // columns-fixed
             values.size(),  // rows-fixed
             1  // 1 depth
     );

     std::vector<float> open_column;
     std::vector<float> close_column;

     float open_value = 0.0;
     float close_value = 0.0;

     std::vector<std::vector<std::tuple<std::string, float, float, float, float, float, float>>>::iterator gg;
     std::vector<std::tuple<std::string, float, float, float, float, float, float>>::iterator g;

     torch::Tensor input_tensor;
     torch::Tensor input;

     gg = values.begin();
     for (int x = 0; x < values.size(); x ++) {
          g = (*gg).begin();

          open_value = std::get<1>(*g);
          close_value = std::get<4>(*g);
          gg ++;

          open_column.push_back(open_value);
          close_column.push_back(close_value);
     }


     for (int x = 0; x < open_column.size(); x ++) {

          open_value = open_column[x];

     std::cout
     << "open_value="
     << open_value
     << std::endl;
     }

     std::cout << std::endl;
     std::cout << std::endl;

     for (int x = 0; x < close_column.size(); x ++) {

          close_value = close_column[x];

     std::cout
     << "close_value="
     << close_value
     << std::endl;
     }

     std::cout << std::endl;
     std::cout << std::endl;


     input_tensor = torch::tensor(
       {
               open_column[52],
               open_column[51],
               open_column[50],
               open_column[49],
               open_column[48],
               open_column[47],
               open_column[46],
               open_column[45],
               open_column[44],
               open_column[43],
               open_column[42],
               open_column[41],
               open_column[40],
               open_column[39],
               open_column[38],
               open_column[37],
               open_column[36],
               open_column[35],
               open_column[34],
               open_column[33],
               open_column[32],
               open_column[31],
               open_column[30],
               open_column[29],
               open_column[28],
               open_column[27],
               open_column[26],
               open_column[25],
               open_column[24],
               open_column[23],
               open_column[22],
               open_column[21],
               open_column[20],
               open_column[19],
               open_column[18],
               open_column[17],
               open_column[16],
               open_column[15],
               open_column[14],
               open_column[13],
               open_column[12],
               open_column[11],
               open_column[10],
               open_column[9],
               open_column[8],
               open_column[7],
               open_column[6],
               open_column[5],
               open_column[4],
               open_column[3],
               open_column[2],
               open_column[1],
               open_column[0]
       },
       torch::kFloat32
     );

     input = model.forward(input_tensor);


     std::cout << std::endl;



     input_tensor = torch::tensor(
       {
               close_column[52],
               close_column[51],
               close_column[50],
               close_column[49],
               close_column[48],
               close_column[47],
               close_column[46],
               close_column[45],
               close_column[44],
               close_column[43],
               close_column[42],
               close_column[41],
               close_column[40],
               close_column[39],
               close_column[38],
               close_column[37],
               close_column[36],
               close_column[35],
               close_column[34],
               close_column[33],
               close_column[32],
               close_column[31],
               close_column[30],
               close_column[29],
               close_column[28],
               close_column[27],
               close_column[26],
               close_column[25],
               close_column[24],
               close_column[23],
               close_column[22],
               close_column[21],
               close_column[20],
               close_column[19],
               close_column[18],
               close_column[17],
               close_column[16],
               close_column[15],
               close_column[14],
               close_column[13],
               close_column[12],
               close_column[11],
               close_column[10],
               close_column[9],
               close_column[8],
               close_column[7],
               close_column[6],
               close_column[5],
               close_column[4],
               close_column[3],
               close_column[2],
               close_column[1],
               close_column[0]
       },
       torch::kFloat32
     );

     input = model.forward(input_tensor);




     return model;
}


CustomModel readCSV
(
     const std::string& pathFile,
     const char chrSplit,
     const int amountTensor
) {
     CustomModel model(1, 1, 1);

     int numLines = 0;

     std::ifstream in(pathFile);
     std::string unused;

     while ( std::getline(in, unused) )
          ++ numLines;

     -- numLines;

     std::ifstream file(pathFile);

     if (!file.is_open()) {
          std::cerr << "Error: Could not open the file." << std::endl;
          return model;
     }

     std::string line;

     std::vector<std::vector<std::string>> rows;

     int config_rows = numLines; // last empty lines should not be counted

     int config_cols = 6;
     int config_all_cols = 7;

     int num_col = 0;
     int num_row = 0;

     std::vector<std::vector<float>> values(config_rows, std::vector<float>(config_cols, 0.0f));

     while (std::getline(file, line)) {
          std::stringstream lineStream(line);
          std::string cell;
          std::vector<std::string> row;

          num_row ++;
          num_col = 0;

          bool valid = true;

          while
          (
               std::getline(lineStream, cell, chrSplit)
          )
          {
               num_col ++;

               if (num_row == 1) {
                    continue;
               }

               if (num_col == 1) {
                    if  (!testConvertDate(cell)) {
                         valid = false;
                    }
               } else {
                    if  (!testConvertFloat(cell)) {
                         valid = false;
                    }
               }

               if (valid) {
                    row.push_back(cell);
               }
          }


          if ((valid) && (row.size() == config_all_cols)) {
               rows.push_back(row);
          }
     }

     std::vector<std::vector<std::tuple<std::string, float, float, float, float, float, float>>> myArr;
     std::vector<std::tuple<std::string, float, float, float, float, float, float>> rowArr;

     std::vector<std::vector<std::string>>::iterator itt_begin = rows.begin();
     std::vector<std::vector<std::string>>::iterator itt_end = rows.end();
     std::vector<std::vector<std::string>>::iterator itt = itt_begin;

     std::string date_str;
     float value_ft_open;
     float value_ft_high;
     float value_ft_low;
     float value_ft_close;
     float value_ft_adj_close;
     float value_ft_volume;

     int rowline = 0;

     for (const auto& row : rows) {
          rowline ++;

          if (row.size() == config_all_cols) {
               try {
                    auto it = (*itt).begin();

                    it = (*itt).begin();

                    date_str = *it;
                    ++ it;

                    value_ft_open = std::stof(*it);
                    ++ it;

                    value_ft_high = std::stof(*it);
                    ++ it;

                    value_ft_low = std::stof(*it);
                    ++ it;

                    value_ft_close = std::stof(*it);
                    ++ it;

                    value_ft_adj_close = std::stof(*it);
                    ++ it;

                    value_ft_volume = std::stof(*it);

                    std::cout << "----------" << std::endl;
                    std::cout << date_str << std::endl;
                    std::cout << value_ft_open << std::endl;
                    std::cout << value_ft_close << std::endl;
                    std::cout << "----------" << std::endl;

                    rowArr.push_back(
                         std::make_tuple(
                              date_str,
                              value_ft_open,
                              value_ft_high,
                              value_ft_low,
                              value_ft_close,
                              value_ft_adj_close,
                              value_ft_volume
                         )
                    );

                    myArr.push_back(rowArr);

                    rowArr.erase(
                         rowArr.begin(),
                         rowArr.end()
                    );

                    ++ itt; 
               }
               catch (const std::exception& e) {
                    continue;
               }
          }
     }

     file.close();

     return getModel(
          myArr,
          amountTensor
     );
}


int main(int argc, char *argv[]) {
     const std::string paramPathFile = "./aes-cotizaciones-historicas.csv";

     const char paramDelimiter = ';';
     const int paramAmountTensor = 53;


     CustomModel model = readCSV(paramPathFile, paramDelimiter, paramAmountTensor);

     return 0;
}


