using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Programß
    {
      static void Main () //Entry Point
        {
            // string greeting = "Hello";
            // greeting = greeting + "World";
            // Console.WriteLine("greeting" + greeting);

            // float side = 3.14F; // How do you find the area of a square? Area = side * side
            // float area = side * side;
            // Console.WriteLine("area: {0}", area);
            // Console.WriteLine(2* 3); // Basic Arithmetic: +, -, /, *
            // Console.WriteLine(10 % 3);  // Modulus Op => remainder of 10/3
            // Console.WriteLine(1 + 2 * 3); // order of operations
            // Console.WriteLine(10 / 3.0); // int's and doubles
            // Console.WriteLine(10 / 3);  // int's 
            // Console.WriteLine("12" + "3");  // What happens here?

            // int num = 10;
            // num += 100;
            // Console.WriteLine(num);
            // num ++;
            // Console.WriteLine(num);

            // bool isCold = true;
            // Console.WriteLine(isCold ? "drink" : "add ice"); // output: drink
            // Console.WriteLine(!isCold ? "drink" : "add ice"); //output: add ice

            // string stringNum = "2";
            // int intNum = Convert.ToInt32(stringNum);
            // Console.WriteLine(intNum);
            // Console.WriteLine(intNum.GetType());

            // Dictonaries //

            // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>();

            // myScoreBoard.Add("firstInning", 10);
            // myScoreBoard.Add("secondInning", 20);
            // myScoreBoard.Add("thirdInning", 30);
            // myScoreBoard.Add("fourthInning", 40);
            // myScoreBoard.Add("fifthInning", 50);

//             Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(){
//     { "firstInning", 10 },
//     { "secondInning", 20},
//     { "thirdInning", 30},
//     { "fourthInning", 40},
//     { "fifthInning", 50}
//             };
// Console.WriteLine("----------------");
// Console.WriteLine("  Scoreboard");
// Console.WriteLine("----------------");
// Console.WriteLine("Inning |  Score");
// Console.WriteLine("   1   |    {0}", myScoreBoard["firstInning"]);
// Console.WriteLine("   2   |    {0}", myScoreBoard["secondInning"]);
// Console.WriteLine("   3   |    {0}", myScoreBoard["thirdInning"]);
// Console.WriteLine("   4   |    {0}", myScoreBoard["fourthInning"]);
// Console.WriteLine("   5   |    {0}", myScoreBoard["fifthInning"]);

// string[] favFoods = new string[3]{ "pizza", "doughtnuts", "icecream" };
// string firstFood = favFoods[0];
// string secondFood = favFoods[1];
// string thirdFood = favFoods[2];
// Console.WriteLine("I like {0}, {1}, and {2}", firstFood, secondFood, thirdFood);

List<string> employees = new List<string>() { "adam", "amy" };
employees.Add("barbara");
employees.Add("billy");
employees.Add("keith");

// Console.WriteLine("My employees include {0}, {1}, {2}, {3}, {4}", employees[0], employees[1], employees[2], employees[3], employees[4]);

for (int i =0; i < employees.Count; i++)
{
    Console.WriteLine(employees[i]);
}
        }
    }
}
