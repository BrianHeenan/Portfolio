# EX06: Strings and Text in Learn Python the hard way
# Created */12/2021
x = "There are %d types of people." % 10 #10 is binary 2
binary = "binary"
do_not = "don't"
y = ("Those who know %s and those who %s"
 % (binary, do_not))

print(x)
print(y)

# %r  means 'raw data' a string containing a representation of an object

print("I said %r." % x)
print("I also said: %s." % y)
hilarious = False
joke_evaluation  = "Isn't that joke so funny: %r"
# define joke as false
print(joke_evaluation % hilarious)
w = "This is the left side of..."
e = "a string with a right side."

print(w + e) # no space
#print(w,e) # built in space