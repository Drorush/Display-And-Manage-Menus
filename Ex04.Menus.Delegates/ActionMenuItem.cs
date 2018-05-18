using System;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItem
    {
        public ActionMenuItem(int i_Index, string i_MenuItemName) : base(i_Index, i_MenuItemName)
        {
            this.MenuItemName = i_MenuItemName;
            this.ItemIndex = i_Index;
        }

        internal override void doWhenChosen(int i_ParentIndex, string i_ParentName)
        {
            notifySystem();
        }

        private void notifySystem()
        {
            if (ReportChosenDelegates != null)
            {
                Console.WriteLine("---- Performing {0} ----", this.MenuItemName);
                ReportChosenDelegates.Invoke();
            }
        }
    }
}
