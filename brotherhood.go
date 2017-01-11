package main

import "fmt"

type Token struct {
	data      string
	recipient int
}

func thread(i int, token Token, ch chan string) {
	if token.recipient == i {
		ch <- "arrived"
	} else {
		ch <- "not arrived"
	}
}

func main() {
	var N int = 20
	token := Token{"data", N}
	ch := make(chan string)
	for i := 1; i <= N; i++ {
		go thread(i, token, ch)
	}
	fmt.Println(<-ch)
}
