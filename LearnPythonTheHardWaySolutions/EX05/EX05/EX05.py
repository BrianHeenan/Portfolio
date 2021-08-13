# EX05:More variables and printing in learning python the hard way.
# Created 8/12/2021

# %d is decimal
# %s is string
my_name = 'Brian P. Heenan'
my_age = 37 # actual age...
my_height = 69 # inches
my_weight = 182 # lbs
my_eyes = 'Blue'
my_teeth = 'White'
my_hair = "Brown"

print("lets talk about %s." % my_name)
print("He's'%d inches tall." % my_height)
print("He's %d pounds heavy." % my_weight)
print("Actually thats not too heavy")
print("He's got %s eyes and %s hair." % (my_eyes, my_hair))
print("His teeth are usually %s depending on how much coffee he drinks." % my_teeth)

# his line is tricky, try to get it right
print("If I add %d, %d, and %d I get %d." % 
      (my_age, my_height, my_weight, (my_age + my_height + my_weight)))
