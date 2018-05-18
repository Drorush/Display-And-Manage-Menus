using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            // FIRST WITH DELEGATES
            Delegates.MainMenu MainMenu = new Delegates.MainMenu("MAIN MENU");
            Delegates.MenuItem ShowDateOrTime = new Delegates.MenuItem(1, "Show Date/Time");
            Delegates.MenuItem VersionAndCapitals = new Delegates.MenuItem(2, "Version And Capitals");
            MainMenu.AddMenuItem(ShowDateOrTime);
            MainMenu.AddMenuItem(VersionAndCapitals);
            Delegates.MenuItem ShowTime = new Delegates.ActionMenuItem(1, "Show Time");
            Delegates.MenuItem ShowDate = new Delegates.ActionMenuItem(2, "Show Date");
            Delegates.MenuItem CountCapitals = new Delegates.ActionMenuItem(1, "Count Capitals");
            Delegates.MenuItem DisplayVersion = new Delegates.ActionMenuItem(2, "Display Version");
            ShowDateOrTime.AddSubItem(ShowTime);
            ShowDateOrTime.AddSubItem(ShowDate);
            VersionAndCapitals.AddSubItem(CountCapitals);
            VersionAndCapitals.AddSubItem(DisplayVersion);
            ShowDate.AttachObserver(new Delegates.ReportChosenDelegate(ShowCurrentDate));
            ShowTime.AttachObserver(new Delegates.ReportChosenDelegate(ShowCurrentTime));
            CountCapitals.AttachObserver(new Delegates.ReportChosenDelegate(CountCapitalsMethod));
            DisplayVersion.AttachObserver(new Delegates.ReportChosenDelegate(DisplayVersionMethod));

            MainMenu.Show();

            // SECOND WITH INTERFACES
        }

        public static void DisplayVersionMethod()
        {
            Console.WriteLine("App Version: 18.2.4.0");
            Console.WriteLine("-----------------------------------");
        }

        public static void CountCapitalsMethod()
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

        public static void ShowCurrentTime()
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Current time is: {0}", localDate.ToShortTimeString());
            Console.WriteLine("-----------------------------------");
        }

        public static void ShowCurrentDate()
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Current date is: {0}", localDate.ToShortDateString());
            Console.WriteLine("-----------------------------------");
        }
    }
}
