import json

print("")
print("Description:")
print("Read value, reverse value, replace characters using this relation rule.")
print("")

print("")
print("A - T")
print("C - G")
print("G - C")
print("T - A")
print("")
print("")

v = input("Input value: ")
v = v.strip()

vv = v[::-1]

relation =\
{
    "A": "T",
    "C": "G",
    "G": "C",
    "T": "A"
}

col_s = []
ss = ""

for rel in relation:    
    s = [ " " for i in v ]    
    index = 0

    for c in vv:
        if c == rel:
            cc = relation[rel]
        else:
            cc = " "

        s[index] = cc 
        index += 1

    col_s.append(s)

iteration = 0

for text in col_s:
    if iteration == 0:
        iteration += 1
        continue
    
    prev_text = col_s[iteration-1]
    cur_text = col_s[iteration]

    index = 0

    for chr in prev_text:
         if cur_text[index] == " " and prev_text[index] != " ":
              cur_text[index] = prev_text[index]

         index += 1
    
    col_s[iteration] = cur_text # update value from array

    iteration += 1

print\
(
    "Output:", 
    "".join\
    (
        col_s[ len(col_s) - 1 ]
    )
)
print("")
