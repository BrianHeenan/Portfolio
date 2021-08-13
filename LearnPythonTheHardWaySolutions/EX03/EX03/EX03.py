#EX03 in learning python the hard way
# Created 8/12/2021
print("I will count my chickens:")

print("Hens", 25 + 30 / 6)
# 1. 30 / 6 = 5
# 2. 25 + "5" = 30

print("Roosters", 100 - 25 * 3 % 4)
#1. 25 * 3 = 75
#2. 75 % 4 = 3 (because 75/4 = 18 r 3
#3. 100 - "3" = 97

print("Now I will count the eggs:")
#Returns a float and you cant have 6.75 egs
#TODO Fix with Math Ceiling?
print( 3 + 2 + 1 - 5 + 4 % 2 - 1 / 4 + 6 )
#1. 4 %  2  = 0 ( 4/2 has no remainder)
#2. 1.0 / 4 = 0.25 needs to make floating point)
#3. 3 + 2 + 1 - 5 + "0" -"0.25" + 6 = 6.75
print("Is it true that 3 + 2 < 5 - 7 ?")
print(3 + 2 < 5 - 7)
print("what is 3 + 2?", 3 + 2)
print("What is 5-7?", 5 - 7)
print("Oh, Thats why its False")
print("How about some more")
print("Is it greater?", 5 > -2)
print("Is it greater or equal?", 5 >= -2)
print("Is it less than or equat?", 5 <= -2)