using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private Dictionary<int, MenuItem> m_MenuItems;
        private string m_MainMenuTitle;

        public MainMenu(string i_MainMenuName)
        {
            m_MenuItems = new Dictionary<int, MenuItem>();
            m_MainMenuTitle = i_MainMenuName;
        }
        public void AddSubItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem.ItemIndex, i_MenuItem);
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine(m_MainMenuTitle);
                Console.WriteLine("================");
                printMenuItems();

                int id = getChosenOption();
                if (id == 0)
                {
                    break;
                }
                MenuItem SubMenu = m_MenuItems[id];
                if (!(SubMenu is ActionMenu))
                {
                    Console.Clear();
                }

                SubMenu.doWhenChosen(SubMenu.ItemIndex, SubMenu.MenuItemName);
            }

        }

        private int getChosenOption()
        {
            Console.WriteLine("Please enter your choice (1-{0}) or 0 to exit:", m_MenuItems.Count);
            string input = Console.ReadLine();
            int chosenOption = -1;
            while (!int.TryParse(input, out chosenOption) || chosenOption < 0 || chosenOption > m_MenuItems.Count)
            {
                Console.WriteLine("Please try again");
                input = Console.ReadLine();
            }

            return chosenOption;
        }

        private void printMenuItems()
        {
            Console.WriteLine("0. Exit");
            foreach (KeyValuePair<int, MenuItem> pair in m_MenuItems)
            {
                Console.WriteLine("{0}. {1}", pair.Key, pair.Value.MenuItemName);
            }
        }

    }
}
