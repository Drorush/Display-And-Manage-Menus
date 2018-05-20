using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenu : MenuItem
    {
        public ActionMenu(int i_Index, string i_MenuItemName) : base(i_Index, i_MenuItemName)
        {
            this.MenuItemName = i_MenuItemName;
            this.ItemIndex = i_Index;
        }
        internal override void doWhenChosen(int i_ParentIndex, string i_ParentName)
        {
            Report();
        }
        public void Report()
        {
            foreach (IOperation op in m_Operations)
            {
                op.Operation();
            }

        }
    }
}
