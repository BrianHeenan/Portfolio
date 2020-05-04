###### *DVP1 - Coding Challenges*
---

# Validation

Unlike your other challenges name this class "Validation.cs" (instead of "CE7-Validation". If you already created a "CE7-Validation" class file, you can right-click on it in your Solutions Explorer window pane and then select "Rename" from the pop-up menu. Click "Yes" if Visual Studio asks if you would like to rename all references to the code. 

The other challenges require validation of user provided data. Doing so verifies that the data meets requested expectations. [Refactor](https://refactoring.com/) your application to perform your challenge validations using the external validation class.

**Note**: *Use this 'Validation' class to validate user entry throughout your project. For example, if you need to validate the user has entered an integer, create a method in your validation class to verify the user input this type of data. Refer to the example below and the suggested types of validation you can perform to understand how this can be done. *

#### Validation Types:
> * String
> * Required Length of String
> * Number of Words
> * Integer 
> * Float
> * Range *- Integer Between Min/Max*

#### Each method should:
> * Prompt the user for the required information
> * Validate user input, requesting it again if necessary
> * Return validated input

##### Example Validation Class:
```
class Validation
{
        // String Required
        public static string ValidateString(string s)
        {
            Console.Write(s);
            string response = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(response))
            {
                Console.Write("\r\nPlease do not leave this empty. Try again: ");
                response = Console.ReadLine();
            }
            return response;
        }    
    ...
}
```
Once completed you shoud be able to refactor your previous challenges. Update them, reducing input gathering to something similar to: 

```
fname = Validation.ValidateString('Please enter your first name...');
Console.WriteLine($"Thanks! You entered {fname}");
```
---