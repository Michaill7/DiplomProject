using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.Models;
using DiplomProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class NewPositionWindowViewModel : ViewModel
    {
        public static List<Elements> actualListOfElements = new List<Elements>() { };
        private List<string> actualPositionsList = new List<string>() { };
        public List<string> ActualPositionList
        {
            get => actualPositionsList;
            set 
            {
                actualPositionsList = value;
                actualPositionListCount = value.Count;
                OnPropertyChange();
            }
        }

        private int choosedPositionIndex;
        public int ChoosedPositionIndex 
        {
            get => choosedPositionIndex;
            set 
            {
                choosedPositionIndex = value;
                choosedPositionIndexForTransfer = value;
                OnPropertyChange();
            }
        }



        private string actualArticul;
        public string ActualArticul 
        {
            get => actualArticul;
            set 
            {
                actualArticul = value;
                actualArticulForTransfer = value;
                OnPropertyChange();
            }
        }

        private string actualName;
        public string ActualName 
        {
            get => actualName;
            set 
            {
                actualName = value;
                actualNameForTransfer = value;
                OnPropertyChange();
            }
        }

        private string actualPrice;
        public string ActualPrice 
        {
            get => actualPrice;
            set 
            {
                actualPrice = value;
                actualPriceForTransfer = value;
                OnPropertyChange();
            }
        }

        private string actualSalePrice;
        public string ActualSalePrice
        {
            get => actualSalePrice;
            set
            {
                actualSalePrice = value;
                actualSalePriceForTransfer = value;
                OnPropertyChange();
            }
        }

        public static int actualPositionListCount;
        public static string actualArticulForTransfer;
        public static string actualNameForTransfer;
        public static string actualPriceForTransfer;
        public static string actualSalePriceForTransfer;
        public static int choosedPositionIndexForTransfer;

        public delegate void WriteDataAboutPositionsInList();
        public static WriteDataAboutPositionsInList WritePositionsInList = null;
        public void WritePropertyToList()
        {
            var a = new List<string>() { };
            foreach (var item in actualListOfElements)
                a.Add($"{item.Name} "+ $"({item.Articul})"+"  "+$"{item.PurchasePrice}|{item.SalePrice}");
            ReWriteList(a);
        }

        public delegate void RemoveDataAboutPositionsInList();
        public static WriteDataAboutPositionsInList RemovePositionsInList = null;
        public void RevovePropertyToList()
        {
            var a = new List<string>() { };
            foreach (var item in actualListOfElements)
                a.Add($"{item.Name} " + $"({item.Articul})" + "  " + $"{item.PurchasePrice}|{item.SalePrice}");
            NewPositionWindowViewModel.actualListOfElements.RemoveAt(NewPositionWindowViewModel.choosedPositionIndexForTransfer);
            a.RemoveAt(choosedPositionIndexForTransfer);
            ReWriteList(a);
        }
        private void ReWriteList(List<string> a) 
        {
            ActualPositionList = a;
        }
        public ICommand AddPositionToListCommand { get; }
        public ICommand RemovePositionFromListCommand { get; }
        public ICommand SaveActualPositionsListInOrderCommand { get; }
        public NewPositionWindowViewModel()
        {
            AddPositionToListCommand = new LyambdaCommand(AddNewPositionToListCommand.AddNewPositionToListExecuted, AddNewPositionToListCommand.AddNewPositionToListCanExecute);
            RemovePositionFromListCommand = new LyambdaCommand(DeletePositionFromListCommand.DeletePositionFromListExecuted, DeletePositionFromListCommand.DeletePositionFromListCanExecute);
            SaveActualPositionsListInOrderCommand = new LyambdaCommand(SavePositionsListInNewOrderCommand.SavePositionsListInNewOrderExecuted, SavePositionsListInNewOrderCommand.SavePositionsListInNewOrderCanExecute);
            WritePositionsInList += WritePropertyToList;
            RemovePositionsInList += RevovePropertyToList;
        }
    }
}
