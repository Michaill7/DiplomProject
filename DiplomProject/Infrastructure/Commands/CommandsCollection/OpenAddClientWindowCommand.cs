using System;
using DiplomProject.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class OpenAddClientWindowCommand
    {
        public static bool OpenNewAddClientWindowCanExecute(object o) => true;
        public static void OpenNewAddClientWindowExecuted(object o) 
        {
            var newAddClientWindow = new AddClient();
            newAddClientWindow.Show();
            newAddClientWindow.Activate();
        }
    }
}
