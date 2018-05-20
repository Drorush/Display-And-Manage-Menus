using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class Actions
    {
        public class ShowCurrentDate : IOperation
        {
            void IOperation.Operation()
            {
                DateTime localDate = DateTime.Now;
                Console.WriteLine("Current date is: {0}", localDate.ToShortDateString());
                Console.WriteLine("-----------------------------------");
            }
        }
        public class ShowCurrentTime : IOperation
        {
            void IOperation.Operation()
            {
                DateTime localDate = DateTime.Now;
                Console.WriteLine("Current time is: {0}", localDate.ToShortTimeString());
                Console.WriteLine("-----------------------------------");
            }
        }
        public class DisplayVersionMethod : IOperation
        {
            void IOperation.Operation()
            {
                Console.WriteLine("App Version: 18.2.4.0");
                Console.WriteLine("-----------------------------------");
            }
        }
        public class CountCapitalsMethod : IOperation
        {
            void IOperation.Operation()
            {
                int count = 0;

                Console.WriteLine("Please enter a text input");
                string input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsUpper(input[i]))
                    {
                        count++;
                    }
                }

                Console.WriteLine("Number of capital letters in {0}: {1}", input, count);
                Console.WriteLine("-----------------------------------");
            }
        }
    }

}
