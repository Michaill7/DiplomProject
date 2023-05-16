using DiplomProject.Models;
using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class AddNewOrderToDB
    {
        public static bool AddNewOrderToDBCanExecute(object o) 
        {
            return true;
        }

        public static void AddNewOrderToDBExecuted(object o) 
        {
            DataBaseClassWorker.AddDataAboutNewOrder();
        }
    }
}
