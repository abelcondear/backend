
def reverse(str):
    lstr = []

    #all characters are set into an array
    for chr in str:
        lstr.append(chr)

    lastindex = len(lstr) - 1 #last position from the string 
    alphachr=[] #character alpha
    nonalphachr=[] #character not alpha
    position = [] #position which stores non-alphabetic character

    for i in range(len(lstr)):
        chr = lstr[lastindex]

        if chr.isalpha(): 
            alphachr.append(chr) #move this element from last to first
        else:
            nonalphachr.append(chr) 
            position.append(lastindex)

        lastindex -= 1
        
    result = []
    curindex = 0
    alphachr_index = 0

    for i in range(len(lstr)):
        active_index = True if curindex in position else False

        if active_index:
            result.append(lstr[curindex])
        else:
            result.append(alphachr[alphachr_index])
            alphachr_index += 1

        curindex += 1

    return "".join(result)


def main():
    # task: reverse the order of alphabetic 
    # characters without moving the non-alphabetic 
    # characters
    print("premise: reverse the order of alphabetic")
    print("characters without moving the non-alphabetic")
    print("characters")
    print("")
    print("Reversing string ...")
    
    print("")
    print("----------")
    
    input = "#$.%"
    output = reverse(input)
          
    print(f"Input: {input}")
    print(f"Output: {output}")

    print("----------")    
    print("")

    input = "abcde"
    output = reverse(input)
    
    print(f"Input: {input}")
    print(f"Output: {output}")
    
    print("----------")   
    print("")

    input = "ab.c"
    output = reverse(input)

    print(f"Input: {input}")
    print(f"Output: {output}")

    print("----------")
    print("")

    input = "#$ab.c%d"
    output = reverse(input)
    
    print(f"Input: {input}")
    print(f"Output: {output}")

    print("----------")

if __name__ == "__main__":
    main()