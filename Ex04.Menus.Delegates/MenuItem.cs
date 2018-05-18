using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ReportChosenDelegate();

    public class MenuItem
    {
        private Dictionary<int, MenuItem> m_SubItems;
        private ReportChosenDelegate m_ReportChosenDelegates;
        private string m_MenuItemName;
        private int m_ID;

        public MenuItem(int i_Index, string i_MenuItemName)
        {
            m_SubItems = new Dictionary<int, MenuItem>();
            MenuItemName = i_MenuItemName;
            m_ID = i_Index;
        }

        public void AddSubItem(MenuItem i_SubItem)
        {
            m_SubItems.Add(i_SubItem.ItemIndex, i_SubItem);
        }

        public string MenuItemName { get => m_MenuItemName; set => m_MenuItemName = value; }

        public ReportChosenDelegate ReportChosenDelegates { get => m_ReportChosenDelegates; set => m_ReportChosenDelegates = value; }

        internal int ItemIndex { get => m_ID; set => m_ID = value; }

        public void AttachObserver(ReportChosenDelegate i_ParentDelegate)
        {
            ReportChosenDelegates += i_ParentDelegate;
        }

        public void DetachObserver(ReportChosenDelegate i_ParentDelegate)
        {
            ReportChosenDelegates -= i_ParentDelegate;
        }

        internal virtual void doWhenChosen(int i_ParentIndex, string i_ParentName)
        {
            while(true)
            {
                Console.WriteLine("{0}. {1}", i_ParentIndex, i_ParentName);
                Console.WriteLine("================");
                printSubItems();
                int chosenOption = getChosenOption();
                if (chosenOption != 0)
                {
                    MenuItem SubMenu = m_SubItems[chosenOption];
                    if (!(SubMenu is ActionMenuItem))
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                    }

                    m_SubItems[chosenOption].doWhenChosen(this.m_ID, this.MenuItemName);
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
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

        private void printSubItems()
        {
            Console.WriteLine("0. Back");
            foreach (KeyValuePair<int, MenuItem> pair in m_SubItems)
            {
                Console.WriteLine("{0}. {1}", pair.Key, pair.Value.MenuItemName);
            }
        }

        protected virtual void notifySystem()
        {
            if (ReportChosenDelegates != null)
            {
                ReportChosenDelegates.Invoke();
            }
        }
    }
}
