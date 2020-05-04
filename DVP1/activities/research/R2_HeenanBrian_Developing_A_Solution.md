## [ DVP1 ] 

* **[ Developing A Solution ]**
* **[ Brian Heenan]**
* **[ 1/26/2020 ]**

This research paper summarizes my time and effort looking into the topic matter outlined below. I have included links and references to research information used for this activity.    

## Topic: Diagram a Process
There are certain techniques used in the industry that can help a developer think through and diagram a logical process. After research into this topic, here's what I have learned...  

**1. UML Stands for...**

[ Unified Modeling Language  ] 

**2. Common Symbols used in UML include...**.

* Beginning Node: [ Is a Black filled in circle. ] 
* Final Node: [Is a filled in circle with a ring around it. ]
* Decision: [ Is a square turned 45 degrees that looks like Dimond shape. ]
* Process: [ Is a pill shaped  symbol. ]
* Action: [ is a square with rounded edges ]
* Control Flow: [ Is an arrow coming off a decision showing a users choice ]


**3. An action in a UML diagram is usually followed by...**

[flow control and a decision ]

**4. An action is a verb, something that takes place. Write a line of code that can represent an action that occurs after a decision point in a program (think of an if/else statement).**

``` C#
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

**5. How many actions are in this statement? "Open the container, pour the fudge, and close the container.**

[ 3- Open, Pour, Close ]

[ https://fso-lms4-immortal-assets.s3.amazonaws.com/724/20193/6b88dcff-2dc4-45d6-a82c-7fe87eb47d1c-e5a988b9-2b6e-4435-8070-997761847c80/diagramming-logical-processes.pdf?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Date=20200126T235018Z&X-Amz-SignedHeaders=host&X-Amz-Expires=600&X-Amz-Credential=AKIAI4QJ7YJDQ7JYMBXQ%2F20200126%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Signature=f960a87cb88d0254d23806a5d7556aecd663b56da33bf4cd0d6c8ddd0185703d ]



## Topic: Document a Process
There are certain techniques used in the industry that can help a developer think through and document a logical process. After research into this topic, here's what I have learned...   

**1. What is an algorithm?**

[A process used to do calculations or solve complex problems ] 

**2. Is there one way to write pseudo-code?**

[ No, Pseudo code is not a standardized process. The First pseido-code I ever used in game Design was A* pathfinding.  https://en.wikipedia.org/wiki/A*_search_algorithm ] 

**3. Provide an example of a simple control-structure used in C#.**

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

[http://faculty.cs.niu.edu/~hutchins/csci473/control.htm]





# References

1. http://faculty.cs.niu.edu/~hutchins/csci473/control.htm
2.  https://en.wikipedia.org/wiki/A*_search_algorithm
3. https://fso-lms4-immortal-assets.s3.amazonaws.com/724/20193/6b88dcff-2dc4-45d6-a82c-7fe87eb47d1c-e5a988b9-2b6e-4435-8070-997761847c80/diagramming-logical-processes.pdf