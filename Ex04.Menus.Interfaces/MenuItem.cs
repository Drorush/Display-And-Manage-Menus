using System;
using System.Collections.Generic;


namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private Dictionary<int, MenuItem> m_SubItems;
        protected List<IObservers> m_ReportObservers = new List<IObservers>();
        private string m_MenuItemName;
        private int m_ID;
        public MenuItem(int i_Index, string i_MenuItemName)
        {
            m_SubItems = new Dictionary<int, MenuItem>();
            MenuItemName = i_MenuItemName;
            m_ID = i_Index;
        }
        public string MenuItemName
        {
            get => m_MenuItemName;
            set => m_MenuItemName = value;
        }
        public int ItemIndex
        {
            get => m_ID;
            set => m_ID = value;
        }

        public void AddSubItem(MenuItem i_MenuItem)
        {
            m_SubItems.Add(i_MenuItem.ItemIndex, i_MenuItem);
        }

        public void AttachObserver(IObservers i_Observer)
        {
            m_ReportObservers.Add(i_Observer);
        }

        public void DetachObserver(IObservers i_Observer)
        {
            m_ReportObservers.Remove(i_Observer);
        }

        internal virtual void doWhenChosen(int i_ParentIndex, string i_ParentName)
        {
            while (true)
            {
                Console.WriteLine("{0}.{1}", i_ParentIndex, i_ParentName);
                Console.WriteLine("================");
                printMenuItems();
                int chosenOption = getChosenOption();
                if (chosenOption != 0)
                {
                    MenuItem SubMenu = m_SubItems[chosenOption];
                    if (!(SubMenu is ActionMenu))
                    {
                        Console.Clear();
                    }

                    m_SubItems[chosenOption].doWhenChosen(this.m_ID, this.MenuItemName);
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }


        private int getChosenOption()
        {
            Console.WriteLine("Please enter your choice (1-{0}) or 0 to go back:", m_SubItems.Count);
            string input = Console.ReadLine();
            int chosenOption = -1;
            while (!int.TryParse(input, out chosenOption) || chosenOption < 0 || chosenOption > m_SubItems.Count)
            {
                Console.WriteLine("Please try again");
                input = Console.ReadLine();
            }

            return chosenOption;
        }

        private void printMenuItems()
        {
            Console.WriteLine("0. Back");
            foreach (KeyValuePair<int, MenuItem> pair in m_SubItems)
            {
                Console.WriteLine("{0}. {1}", pair.Key, pair.Value.MenuItemName);
            }
        }
    }
}
