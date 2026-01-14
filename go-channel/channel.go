package main

import "fmt"

//Looking channel n
//Jumping k channels
//What channel remains

func output(n int, k int) int {
	var m int

	m = 1 + k

	//fmt.Printf("%d + %d=%d", 1, k, 1+k)
	//fmt.Println("")	

	for i:= 0; i <= n; i ++ {
		//fmt.Printf("%d + %d=%d", m, k, m+k)
		//fmt.Println("")	

		if m+k >= n {
			break
		}

		m = m + k


	}

	//fmt.Println("")	
	//fmt.Println("")	

	return m
}

func main() {
	fmt.Printf("Seek channel %d\n", 5)
	fmt.Printf("Jumps %d\n", 2)
	fmt.Printf("Available channel is %d\n\n", output(5, 2))

	fmt.Printf("Seek channel %d\n", 6)
	fmt.Printf("Jumps %d\n", 2)
	fmt.Printf("Available channel is %d\n\n", output(6, 2))

	fmt.Printf("Seek channel %d\n", 7)
	fmt.Printf("Jumps %d\n", 3)	
	fmt.Printf("Available channel is %d\n", output(7, 3))
}
