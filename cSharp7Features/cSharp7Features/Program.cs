using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
//Install-Package System.Threading.Tasks.Extensions -Version 4.3.0

//install-package System.ValueTuple

/*
 Features

Support for Local functions
Enhanced support for Tuple Types
Record Types
Pattern matching
Non Nullable reference types
Immutable types
Better support for out variables

 */
namespace cSharp7Features
{
 
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to C#7.0 Features's Demo");
            TupleDemo();
            LocalFunctionDemo();
            OutVariableImpl("11");
            var duration = ValueTaskUsage(10);
            Task.Delay(15);
            WriteLine("Output Got from async method returning ValueTask - " + duration);
            BitSeperatorUsage();
            ExpressionBodyInConstructDestructUsage();

            PatternMatch();
             
            ReadLine();
        }
      
    
    private static void PatternMatch()
        {
            WriteLine("----------------------");
            string Name = "Ketan";
            WriteLine("Name is string ? - " + (Name is string));
        }

        private static void ExpressionBodyInConstructDestructUsage()
        {
            Employee obj;
            using (obj = new Employee("Ketan"))
            {
                WriteLine("----------------------");
                WriteLine("ClassMember Set by ConstructorExpressionBody is - " + obj.FirstName);
            }
        }


        public class Employee : IDisposable
        {
            public Employee(string firstName) => this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));


            ~Employee() => Error.WriteLine("Employee Obj Disposed!");

            private string firstName;
            public string FirstName
            {
                get => firstName;
                set => this.firstName = value ?? "Mr.";
            }

            public void Dispose()
            {
                WriteLine("Employee Obj Disposed!");
            }
        }

        private static void BitSeperatorUsage()
        {
            WriteLine("----------------------");
            const int OneHundredTwentyEight = 0b1100_0010; // binary representation for 194
            const decimal GoldenRatio = 1.618_033_988_749_894_848_9M;
            WriteLine("Bit Seperator Usage " + OneHundredTwentyEight + "----" + GoldenRatio);
        }

        public static async ValueTask<int> ValueTaskUsage(int delay)
        {
            WriteLine("----------------------");
            await Task.Delay(delay);
            return delay;
        }

        public static void OutVariableImpl(string agestr)
        {
            WriteLine("----------------------");
            if (int.TryParse(agestr, out int ageInt))
                WriteLine("Age in int after parsing - " + ageInt);
            else
                WriteLine("Error !!");
        }

        private static void LocalFunctionDemo()
        {
            WriteLine("----------------------");
            WriteLine("Local Function Demo");
            //Function inside function
            void GetMyTaxForThisYear(int salary, double tax)
            {
                WriteLine("tax for salary " + salary + " is - " + salary * tax);
            }

            GetMyTaxForThisYear(700000, 0.10);
        }

        private static void TupleDemo()
        {
            WriteLine("----------------------");
            WriteLine("Tuple Demo");
            var flight = GetFlightInfo();
            WriteLine("flight.Item1" + flight.Item1 + " - " + flight.Item2 + flight.Item3 + " - " + flight.Item4);
            var ketanData = GetKetanInfo();
            WriteLine("Education-" + ketanData.edu + " - Experience " + ketanData.exp);
            (string ketanEdu, int KetanExp) = GetKetanInfo();
            WriteLine("Education-" + ketanEdu + " - Experience " + KetanExp);
        }

        public static (string, string, string, string) GetFlightInfo()
        {
            string flightName = "Air Indian";
            string flightNo = "C123";
            string startCity = "Mumbai";
            string endCity = "Colombo";
            return (flightName, flightNo, startCity, endCity);
        }
        public static (string edu, int exp) GetKetanInfo()
        {
            return ("BEIT", 5);
        }
    }
}
