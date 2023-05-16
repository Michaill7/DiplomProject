using DiplomProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class OpenActualListOfClientsCommand
    {
        public static bool OpenActualListOfClientsCanExecute(object o) => true;

        public static void OpenActualListOfClientsExecute(object o) 
        {
            var newChooseClientsWindow = new ActualListOfClientsWindow();
            newChooseClientsWindow.Show();
            newChooseClientsWindow.Activate();
        }
    }
}
