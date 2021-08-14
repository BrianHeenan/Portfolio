#learn Python the hard way by Zed shaw
#EX08: Printing, Printing
#Created 08/13/2021

formatter = "%r %r %r %r" #r can read any raw data

print(formatter % (1, 2, 3, 4))
print(formatter % ("One", "Two", "Three", "Four"))
print(formatter % (True, False, False, True))
# will read %r as literal text
print(formatter % (formatter, formatter, formatter, formatter))

print(formatter % (
    "I hade this thing.",
   "That you could type up right.", 
   "But it couldnt din't sing.",
   "So I said goodnight.")
      )

