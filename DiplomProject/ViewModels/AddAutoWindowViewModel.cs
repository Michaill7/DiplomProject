using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class AddAutoWindowViewModel : ViewModel
    {
        private string newVIN;
        public string NewVIN 
        {
            get => newVIN;
            set 
            {
                newVIN = value;
                newVINForTransfer = value;
                OnPropertyChange();
            }
        }
        private string newMarka;
        public string NewMarka 
        {
            get => newMarka;
            set 
            {
                newMarka = value;
                newMarkaForTransfer = value;
                OnPropertyChange();
            }
        }
        private string newModel;
        public string NewModel 
        {
            get => newModel;
            set 
            {
                newModel = value;
                newModelForTransfer = value;
                OnPropertyChange();
            }
        }
        private string newYear;
        public string NewYear 
        {
            get => newYear;
            set 
            {
                newYear = value.ToString();
                newYearForTransfer = value.ToString();
                OnPropertyChange(); 
            }
        }

        public static string newVINForTransfer;
        public static string newMarkaForTransfer;
        public static string newModelForTransfer;
        public static string newYearForTransfer;

        public ICommand SaveDataAboutAutoCommand { get; }

        public AddAutoWindowViewModel()
        {
            SaveDataAboutAutoCommand = new LyambdaCommand(SaveInfoAboutNewAutoCommand.SaveInfoAboutNewAutoExecuted, SaveInfoAboutNewAutoCommand.SaveInfoAboutNewAutoCanExecute);
        }

    }
}
