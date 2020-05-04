## [ JavaScript] 

* **[ Learn JavaScript ]**
* **[ Brian Heenan]**
* **[ 5/03/2020 ]**

This research paper summarizes my time and effort looking into the topic matter outlined below. I have included links and references to research information used for this activity.    

## Topic: JavaScript Basics
There are certain techniques used in the industry that can help a developer think through and diagram a logical process. After research into this topic, here's what I have learned...  

**1. What Is JavaScript...**

[  ] 

**2. JavaScript is whitespace nuteral. **.

* 
* 
* 
* 
* 
**3. JavaScript is case sensitive**


**4. How do you use comments in JavaScript**
[]
//Single line comment
/*
Multi-
line-
comment
*/
**5. How can you outy put to the user in JavaScript. **

alert("This is an Alert message!")

showMessage("Massage is changes");

showVariable(price);

console.log("Any message here");
**6. How can you declare a variable in Javascript**

declare a variable
	let total = 100.00;
	
declare a string variable
	let welcome = 'welcome';
	
declare a boolean variable
	let discounted = true;

					Best practices
It is best practoices to have one "let" followed by comma seperation
						Example:
let price = 100.00,
	name= 'Dancing shoes',
		discounted = false;
		
**6. What are protected key words and some examples of them in JavaScript**

				protected keywords
	let -- declares a variable
	const-- declares a constant
	var -- creates a variable

**5. Describe  a decicion and an action using Javascript Syntax **

``` JavaScript 
--------------------DECISION-------------------------
Console.WriteLine(" Welcome to TempConvert.Would you like to...\r\n " 
                "1.Convert temperature from Fahrenheit to Celsius \r\n " +
                "2.Convert temperature from Celsius to Fahrenheit \r\n " +
                "3.Convert temperature from Fahrenheit to Kelvin \r\n " +
                "4.Convert temperature from Celsius to Kelvin");

----------------------ACTION-------------------------
[if (inputString == "1")
            {
                Console.WriteLine("OK, what temperature in  Fahrenheit would you like to convert?");
                convertString =  Console.ReadLine();
          	   FahrenheitToCelcius();

            }
            else if (inputString == "2")
            {
                Console.WriteLine("OK, what temperature in  Celsius would you like to convert?");
                convertString = Console.ReadLine();
                CelciusToFahrenheit();
            }
            else if (inputString == "3")
            {
                Console.WriteLine("OK, what temperature in Fahrenheit would you like to convert?");
                convertString = Console.ReadLine();
                FahrenheitToKelvin();
            }
            else if (inputString == "4")
            {
                Console.WriteLine("OK, what temperature in Celsius would you like to convert?");
                convertString = Console.ReadLine();
                CelciusToKelvin();

            }
            else
            {
                //invalid input. re-Ask
                Console.WriteLine("Please Enter a valid number");
                inputString = Console.ReadLine();
                ValidateStringInput();
                UserSelction(inputString);
            }]
 
```

**6. **

[]

[ ]



## Topic: Varables and Constants
There are certain techniques used in the industry that can help a developer think through and document a logical process. After research into this topic, here's what I have learned...   

**1.**

[] 

**2. **

[  ] 

**3. Provide an example of a simple control-structure used in JavaScript.**

``` 

[  public static void ValidateLenght()
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsWhiteSpace(inputString[i]) == true)
                {
                    wordCount++;
                }
            }
---------------Control Structure Example-------------
Flow 1--------->if (wordCount + 1 >= 6)
            {
                Console.WriteLine("Word count is " + wordCount);
            }
Flow 2---------> else
           {
                Console.WriteLine("Please enter at least 6 words");
                inputString = Console.ReadLine();
                ValidateLenght();
           }
        }]
 
```

[]

## Topic: Types and Opperators

## Topic: Program Flow

## Topic: Functions

## Topic: Objects

## Topic: The DOM

## Topic: Arrays

## Topic: Scope
## Topic: Hoisting
  

## Topic: 

**1. **


**2. **

## Topic: 
Version control, also known as revision control, records changes to a file or set of files over time so that you can recall specific versions later. In this class, we are learning Git. Here's what I have learned. 

**1. There are three types of version control.**

**2. Using Terminal, there are essential Git commands I must know.**

**3. Authenticating with GitHub from Git.**
**4.**  

# References









	//Varables  must start with either either _ $ or a letter
	//Varables  can contain  either _ $   letter or number
	//Variables cannot begin with number

	//cammelCase is the prefered notation in JavaScript

	//$Variable is generally discouraged in code

	//Constants are immutable  and connot be changed after it is created
	//Constants must be initalized.
	const priceTheNeverChanges = 49.99
	//Best practice Delcare everything that can be a constant as a Const, 
	//then everything else as let
	//avoid Var

	// var is not a prefered method because 
	//it alows you to referance a variable before it is declared and initalized 
	//this can couse some logic and syntax issues to go undandled deespit the code running.
	
	/* 
	showMessage(price)
	var price = 25;

	 if this code was by itself show message would be consided "undefined" 
	 when it was actually never initalized before it was referanced.
	 the let or const keywords would have throw an actual error.
	 */