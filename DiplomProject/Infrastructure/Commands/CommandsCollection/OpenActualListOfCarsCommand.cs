using DiplomProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class OpenActualListOfCarsCommand
    {
        public static bool OpenActualListOfCarsCanExecute(object o) => true;

        public static void OpenActualListOfCarssExecute(object o)
        {
            var newChooseCarssWindow = new ActualListOfCarsWindow();
            newChooseCarssWindow.Show();
            newChooseCarssWindow.Activate();
        }
    }
}
