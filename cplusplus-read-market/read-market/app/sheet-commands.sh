# ---------------------------
# linux terminal command
# ---------------------------
#
#  --- python torch installation ---
#  apt install python3-torch
#
#  --- build app ---
#  cmake --build . --config Release
#
#  --- remove and build app ---
#  rm -r ./build/ || true && cmake -S . -B ./build/
#  rm -r ./build/ || true && cmake -S . -B ./build/ && cp readMarket.cpp ./build/ && cmake --build ./build --config Release && ./build/readMarket
#  rm -r ./build/ && cmake -S . -B ./build/
#
#  --- create build folder and import library  ---
#  cmake -S . -B ./build/
#  cmake -DCMAKE_PREFIX_PATH=$(python3 -c "import torch; print(torch.utils.cmake_prefix_path)")
#
#  --- copy source code to build folder and build app ---
#  cp readMarket.cpp ./build/ && cmake --build ./build --config Release && ./build/readMarket
#  cp readMarket.cpp ./build/ && cp apple-inc-appl.csv ./build/ && cmake --build ./build --config Release && ./build/readMarket
#  cp readMarket.cpp ./build/ && cmake --build ./build --config Release && ./build/readMarket > output.log && nano output.log
#
#  --- create binary program  ---
#  g++ readMarket.Generated.cpp -o readMarket.Generated
#  ./readMarket.Generated --amount=53 --delimiter=";" --pathFile="./aes-cotizaciones-historicas.csv"
#
#  --- create binary program using parameter for Tensorflow library ---
#  g++ readMarket.cpp -o readMarket -ltensorflow
#  ./readMarket
#
#  --- reference ---
#  https://developer.download.nvidia.com/compute/cuda/repos/ubuntu2604/x86_64/
#
#  --- open excel document ---
#  xdg-open AES_Cotizaciones_Historicas.xls
#
# ---------------------------

