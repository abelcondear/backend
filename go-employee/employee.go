package main

import (
	"fmt"
	"time"
	"math/rand"
	"math"
	"bufio"
	"extra/workinghours"
	"container/list"
	"os"
	"os/exec"
    "runtime"	
	"sync"
	ss "strings"
)

var wg sync.WaitGroup

var listEmp *list.List
var listShift *list.List
var listContract *list.List
var callPrintNewEmployee int = 0
var clear map[string]func() //create a map for storing clear funcs

type Shift struct {
	Name        string //capital letter : public member
	
	Start float64 
	End float64
}

type Contract struct {
	Name	string 	//capital letter : public member
}

type Employee struct {
	Name        string //capital letter : public member
	
	Age         int
	JobName 	string
	Salary      int
	
	HoursWorked float64
	ExtraHoursWorked float64

	timeStart time.Time //non-capital letter: private member
	timeEnd time.Time
}


func (e *Employee)rangeRand(max int, min int) int {
	return rand.Intn(max-min) + min
}

func (e *Employee)Quit() {
	e.timeEnd = time.Now().Local().Add(time.Hour * 
		time.Duration(e.rangeRand(14,6)) + 
		time.Minute * 
		time.Duration(0) + 
		time.Second * 
		time.Duration(0)) // the variable type is defined in execution time
	
	//fmt.Println(e.timeStart)
	//fmt.Println(e.timeEnd)

	difference := e.timeEnd.Sub(e.timeStart)

	e.HoursWorked = difference.Hours()
	return
}

func (e *Employee)Start() {
	e.timeStart = time.Now() // the variable type is defined in execution time	
	return
}

func CallClear() {
    value, ok := clear[runtime.GOOS] //runtime.GOOS -> linux, windows, darwin etc.
    if ok { //if we defined a clear func for that platform:
        value()  //we execute it
    } else { //unsupported platform
        panic("Your platform is unsupported! I can't clear terminal screen :(")
    }
}

func PrintMenu()  {

	CallClear()

	fmt.Printf("\n\n")
	fmt.Printf("1. New Empployee\n")
	fmt.Printf("2. Update Employee\n")
	fmt.Printf("3. Delete Employee\n")
	fmt.Printf("4. List\n")
	fmt.Printf("5. Exit\n")
	fmt.Printf("Enter option:")

	option := getInput()

	if  option == "1" { PrintNewEmployee() }
	if  option == "2" { PrintUpdateEmployee() }
	if  option == "3" { PrintDeleteEmployee() }	
	if  option == "4" { PrintListEmployee() }
	if  option == "5" { os.Exit(0) }	

}


func PrintListEmployee() {
	fmt.Printf("\n\n")

	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:
			fmt.Printf("Name: %s\n", v.Name)
		}
	}

	fmt.Printf("Press Enter to exit.")
	getInput()

	CallClear()

	PrintMenu()
	
}

func PrintNewEmployee() {
	var text string
	var input string

	//fmt.Printf("\n\n")
	input = ""

	if callPrintNewEmployee == 0 { fmt.Printf("\n") }

	fmt.Printf("Name:")
	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		text = scanner.Text()
		if text != "" { 
			input = text 
			break
		}
		if text == "" {
			break
		}
	}

	var newEmp Employee

	newEmp.Name = input
	
	listEmp.PushBack(newEmp)

	callPrintNewEmployee += 1

	if callPrintNewEmployee == 4 {
		PrintMenu()
	} else {		
		PrintNewEmployee()
	}

}

func PrintUpdateEmployee() {

	fmt.Printf("\n\n")


	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:
			fmt.Printf("Name: %s\n", v.Name)
		}
	}
	
	fmt.Printf("Enter Name you wish to update:")

	option := getInput()

	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:

			if ss.Contains(v.Name, option) {
				fmt.Printf("Are you sure you want to update \"%s\"? (Y/N) ", v.Name)
				option := getInput()
				
				if option == "Y" { 
					listEmp.Remove(e)


					fmt.Printf("Name: ")
					name := getInput()

					var newEmp Employee

					newEmp.Name = name

					listEmp.PushBack(newEmp)
					fmt.Printf("\"%s\" was updated. Updated Name: %s\n", v.Name, newEmp.Name) 

					fmt.Printf("Press Enter to exit.")
					getInput()
					CallClear()
				}
			}

		}
	}	
	
	
	PrintMenu()
	//os.Exit(0)
}

func PrintDeleteEmployee() {

	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:
			fmt.Printf("Name: %s\n", v.Name)
		}
	}
	
	fmt.Printf("Enter Name you wish to delete:")

	option := getInput()

	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:

			if ss.Contains(v.Name, option) {
				fmt.Printf("Are you sure you want to delete \"%s\"? (Y/N) ", v.Name)
				option := getInput()
				
				if option == "Y" { 
					listEmp.Remove(e)
					fmt.Printf("\"%s\" was deleted\n", v.Name) 
					
					fmt.Printf("Press Enter to exit.")
					getInput()
					CallClear()					
				}
			}

		}
	}	

	PrintMenu()
	//os.Exit(0)
}

func getInput() string {
	var text string
	var data string

	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		text = scanner.Text()
		if text != "" { 
			data = text 
			break
		}

		if text == "" {
			break
		}
	}
			
	return data
}

func addEmployee(addEmployeeFunc *sync.Mutex) {
	defer wg.Done()

	addEmployeeFunc.Lock()

	listEmp = list.New()	
	var newEmp Employee

	newEmp.Start()
	newEmp.Quit()	

	newEmp.Name = "John Mann"
	newEmp.Age = 39	

	var workingHours = workinghours.Get()
	newEmp.ExtraHoursWorked =  math.Abs(workingHours.Normal - newEmp.HoursWorked)

	listEmp.PushBack(newEmp) 

	newEmp.Start()
	newEmp.Quit()	

	newEmp.Name = "Mark London"
	newEmp.Age = 47	

	workingHours = workinghours.Get()
	newEmp.ExtraHoursWorked =  math.Abs(workingHours.Normal - newEmp.HoursWorked)

	listEmp.PushBack(newEmp) 

	n := 0
	
	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nEmployee List---------------\n\n")
		}

		switch v := i.(type) {
		case Employee:
			fmt.Printf("Employee Name: %s\n", v.Name)
			fmt.Printf("Employee Age: %.2d\n", v.Age)
			fmt.Printf("Expected Hours to be Worked: %.2f\n", workingHours.Normal)	
			fmt.Printf("Hours Worked: %.2f\n", v.HoursWorked)	
			fmt.Printf("Extra Hours Worked: %.2f\n", v.ExtraHoursWorked)	
			fmt.Printf("\n")
			//fmt.Printf("This is Employee type: %#v\n", v)
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addEmployeeFunc.Unlock()	
}

func addShift(addShiftFunc *sync.Mutex) {
	defer wg.Done()

	addShiftFunc.Lock()
	
	listShift = list.New()
	var newShift Shift

	newShift.Name = "Full Time" 
	newShift.Start = 9.0
	newShift.End = 18.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 9.0
	newShift.End = 14.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 14.0
	newShift.End = 19.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 19.0
	newShift.End = 00.0
	listShift.PushBack(newShift)

	
	n := 0

	for e := listShift.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nShifts List-----------------\n\n")
		}

		switch v := i.(type) {
		case Shift:
			fmt.Printf("Shift Name: %s\n", v.Name)
			fmt.Printf("Shift Description: starts from %.2f to %.2f\n", v.Start, v.End)
			fmt.Printf("\n") 
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addShiftFunc.Unlock()
}

func addContract(addContractFunc *sync.Mutex) {
	defer wg.Done()

	addContractFunc.Lock()

	listContract = list.New()
	var newContract Contract

	newContract.Name = "Contract - 6 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 12 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 18 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 24 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - Undetermined Time"
	listContract.PushBack(newContract)

	n := 0

	for e := listContract.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nContracts List -------------\n\n")
		}

		switch v := i.(type) {
		case Contract:
			fmt.Printf("Contract Name: %s\n", v.Name)
			fmt.Printf("\n")
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addContractFunc.Unlock()
} 

func init() {
    clear = make(map[string]func()) //Initialize it
    clear["linux"] = func() { 
        cmd := exec.Command("clear") //Linux example, its tested
        cmd.Stdout = os.Stdout
        cmd.Run()
    }
    clear["windows"] = func() {
        cmd := exec.Command("cmd", "/c", "cls") //Windows example, its tested 
        cmd.Stdout = os.Stdout
        cmd.Run()
    }
}

func main() {	
	
	// uncomment this in case you need to see the shift/contract/employee list
	//wg.Add(3)

	//addEmployeeFunc := &sync.Mutex{}
	//addShiftFunc := &sync.Mutex{}
	//addContractFunc := &sync.Mutex{}

	//go addShift(addShiftFunc)
	//go addContract(addContractFunc)
	//go addEmployee(addEmployeeFunc)
	
	//wg.Wait()

	
	listEmp = list.New()
	PrintMenu()

}
