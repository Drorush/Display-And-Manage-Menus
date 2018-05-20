using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    interface IMenu
    {
        string MenuItemName { get; set; }
      
        int ItemIndex { get; set; }
       
        void AddSubItem();
        void doWhenChosen();
        int getChosenOption();
        void printSubItems();
    }
}
