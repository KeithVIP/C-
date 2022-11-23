// Import correct packages
using System;
using System.IO;
using System.Collections.Generic; // containes dictionary and list methods
using System.Net.Http; // short method
using SkiaSharp;
using System.Threading.Tasks; // contains task object

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // Add List parameter to method
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                // each iteration in employees is now an Employee instance
                string template = "{0,-10}\t{1,-20}\t{2}";

                // new code
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }
        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create it
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");

                // Loop over employees
                for (int i = 0; i < employees.Count; i++)
                {
                    // Write each employee to the file
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }
        async public static Task MakeBadges(List<Employee> employees)
        {
            // Laout variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            // employee photo coordinates
            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;

            //company name
            int COMPANY_NAME_Y = 150;

            //employee name
            int EMPLOYEE_NAME_Y = 600;

            //employee ID 
            int EMPLOYEE_ID_Y = 730;

            // instance of HttpClient is disposed after code in the block has run
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    // keeps portrait
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                    // keeps badge
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT); // create SKBitmap
                    SKCanvas canvas = new SKCanvas(badge); // create SKCanvas object

                    SKPaint paint = new SKPaint();
                    paint.TextSize = 42.0f;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.White;
                    paint.IsStroke = false;
                    paint.TextAlign = SKTextAlign.Center;
                    paint.Typeface = SKTypeface.FromFamilyName("Arial");
                    canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT)); //SKRect allows us to allocate a postion and size on the badge

                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    // Company name
                    canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);

                    paint.Color = SKColors.Black;

                    // Employee name
                    canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);

                    paint.Typeface = SKTypeface.FromFamilyName("Courier New");

                    // Employee ID
                    canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);

                    // final call/display
                    SKImage finalImage = SKImage.FromBitmap(badge);
                    SKData data = finalImage.Encode();
                    string template = "data/{0}_badge.png";
                    data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));


                }
            }
            // Create image
            // SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

            // SKData data = newImage.Encode();
            // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
        }
    }
}