using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create variables.
            string name = "Jeremy Alkire";
            string location = "United States of America";
            var dateToday = DateTime.Now;
            var christmas = new DateTime(2020, 12, 25, 19, 0, 0);

            // Write to the console.
            Console.WriteLine($"My name is {name}. I am from the {location}.");
            Console.WriteLine($"The current day of the week is: {dateToday.DayOfWeek}.");

            // Subtract the date of Christmas from the date of today.
            System.TimeSpan difference = christmas.Subtract(dateToday);

            // Display how may days there are between now and Christmas 2020.
            Console.WriteLine($"There are {difference.TotalDays} days until Christmas 2020.");

            /**************************************************************************************
             *                               
             *                               EXAMPLE PROGRAM: 2.1.1   
             *                               
            ***************************************************************************************/

            // Create the variables.
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            // Request a width.
            Console.WriteLine("Please enter a width:");
            widthString = Console.ReadLine(); // Store the entered width.
            width = double.Parse(widthString); // Parse to double.

            // Request a height.
            Console.WriteLine("Please enter a height:");
            heightString = Console.ReadLine(); // Store the entered height.
            height = double.Parse(heightString); // Parse to double.

            // Arithmetic.
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            // Output to console.
            Console.WriteLine("The length of the wood is " + woodLength + " feet");
            Console.WriteLine("The area of the glass is " + glassArea + " square metres");
        }
    }
}
