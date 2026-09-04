cmake_minimum_required(VERSION 3.18 FATAL_ERROR)
project(readMarket)

# ------------------------
#set(CMAKE_CXX_STANDARD 17)

# tensorflow directory
# include_directories(/usr/local/lib/)

#include_directories(/path/to/tensorflow)
#include_directories(/path/to/tensorflow/bazel-bin)

#include_directories(/usr/include/eigen3/Eigen)
#include_directories(/usr/local/include/third_party/xla/third_party/tsl/)
#include_directories(/usr/local/include/third_party/xla/third_party/tsl/tsl/)
#include_directories(/usr/local/include/third_party/xla/xla/tsl/)

#include_directories(/usr/local/include/tensorflow/)

#include_directories(/home/scott/Documents/Me/Programs/backend/c++/readMarket-v7.0/app/read-market/tensorflow/)

link_directories(/usr/local/lib/)

#add_executable(predict main.cpp)
#target_link_libraries(predict tensorflow_cc)
# ------------------------

execute_process(
    COMMAND python3 -c "import torch; print(torch.utils.cmake_prefix_path)"
    OUTPUT_VARIABLE TORCH_CMAKE_PATH
    OUTPUT_STRIP_TRAILING_WHITESPACE
)

execute_process(
   COMMAND cp ./readMarket.cpp ./build/
   COMMAND cp ./apple-inc-appl.csv ./build/
   COMMAND cp ./aes-cotizaciones-historicas.csv ./build/
   #COMMAND cp -r ./tensorflow ./build/
)

find_package(Boost REQUIRED)
find_package(Torch REQUIRED)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} ${TORCH_CXX_FLAGS}")

add_executable(readMarket readMarket.cpp)

target_link_libraries(readMarket "${TORCH_LIBRARIES}")
#target_link_libraries(readMarket tensorflow_cc)
#target_link_libraries(readMarket tensorflow_framework)

# -I/path/to/tensorflow \
# -I/path/to/tensorflow/bazel-bin \
# -ltensorflow_cc -ltensorflow_framework

set_property(TARGET readMarket PROPERTY CXX_STANDARD 20)

# The following code block is suggested to be used on Windows.
# According to https://github.com/pytorch/pytorch/issues/25457,
# the DLLs need to be copied to avoid memory errors.
if (MSVC)
  file(GLOB TORCH_DLLS "${TORCH_INSTALL_PREFIX}/lib/*.dll")
  add_custom_command(TARGET readMarket
                     POST_BUILD
                     COMMAND ${CMAKE_COMMAND} -E copy_if_different
                     ${TORCH_DLLS}
                     $<TARGET_FILE_DIR:readMarket>)
endif (MSVC)
