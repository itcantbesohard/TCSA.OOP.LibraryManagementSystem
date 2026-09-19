using System;
using System.Collections.Generic;
using System.Text;

namespace TCSA.OOP.LibraryManagementSystem.Controllers
{
    internal interface IBaseController
    {
        void ViewItems();
        void AddItem();
        void DeleteItem();

    }
}
