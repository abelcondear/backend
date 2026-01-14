module pluseq

let inline (+=) (x : byref<_>) y = x <- x + y

