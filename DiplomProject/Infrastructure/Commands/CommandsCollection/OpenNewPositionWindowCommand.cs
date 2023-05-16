using DiplomProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class OpenNewPositionWindowCommand
    {
        public static bool OpenNewPositionWindowCanExecute(object o) => true;
        public static void OpenNewPositionWindowExecute (object o)
        {
            var NewPosWindow = new NewPositinonWindow();
            NewPosWindow.Show();
            NewPosWindow.Activate();
        }
    }
}
