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
using static ScottPlot.Generate;

namespace DiplomProject.ViewModels
{
    internal class NewOfferWindowViewModel : ViewModel
    {
        private double orderSum;
        public double OrderSum
        {
            get => orderSum;
            set
            {
                try
                {
                    orderSum = Convert.ToDouble(value);
                    orderSumForTransfer = Convert.ToDouble(value);
                    OnPropertyChange();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение данного поля должно быть числом с плавающей точкой");
                }
            }
        }
        private System.DateTime orderDate = System.DateTime.Today;
        public System.DateTime OrderDate
        {
            get => orderDate;
            set
            {
                try
                {
                    orderDate = Convert.ToDateTime(value);
                    orderDateForTransfer = Convert.ToDateTime(value);
                    OnPropertyChange();
                } catch (FormatException)
                {
                    MessageBox.Show("Значение данного поля должно быть датой");
                }
            }
        }

        private int orderDaysCount;
        public int OrderDaysCount
        {
            get => orderDaysCount;
            set
            {
                try
                {
                    orderDaysCount = Convert.ToInt32(value);
                    orderDaysCountForTransfer = Convert.ToInt32(value);
                    OnPropertyChange();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение данного поля должно быть числом");
                }
            }
        }

        private string orderComment;
        public string OrderComment
        {
            get => orderComment;
            set
            {
                orderComment = value;
                orderCommentForTransfer = value;
                OnPropertyChange();
            }
        }


        private string choosedVIN;
        public string ChoosedVIN
        {
            get => choosedVIN;
            set 
            {
                choosedVIN = value;
                OnPropertyChange();
            }
        }
        public delegate void AddNoteFileToListDel();
        public static AddNoteFileToListDel AddNoteDel = null;
        public void AddNoteFileToList()
        {
            ChoosedVIN = choosedVINForTransfer;
        }



        private string choosedClientPhone;
        public string ChoosedClientPhone 
        {
            get => choosedClientPhone;
            set 
            {
                choosedClientPhone = value;
                OnPropertyChange();
            }
        }
        public delegate void WritePropertyPhoneForTransfer();
        public static WritePropertyPhoneForTransfer WriteClientProperty = null;
        public void WritePropertyToList() 
        {
            ChoosedClientPhone = choosedClientPhoneNumberForTransfer;
        }

        public static List<Elements> actualElementsOfPositions = new List<Elements>() { };

        public static double orderSumForTransfer = 0;
        public static System.DateTime orderDateForTransfer = System.DateTime.Now;
        public static int orderDaysCountForTransfer = 0;
        public static string orderCommentForTransfer = "";
        public static string choosedVINForTransfer = "";
        public static string choosedClientPhoneNumberForTransfer;

        public ICommand NewOfferWindowOpen { get; }
        public ICommand NewAddAutoWindowOpen { get; }
        public ICommand NewAddClientWindowOpen { get; }
        public ICommand ChooseClientWindowOpen { get; }
        public ICommand ChooseCartWindowOpen { get; }
        public ICommand AddNewOrderCommand { get; }
        public NewOfferWindowViewModel()
        {
            NewOfferWindowOpen = new LyambdaCommand(OpenNewPositionWindowCommand.OpenNewPositionWindowExecute, OpenNewPositionWindowCommand.OpenNewPositionWindowCanExecute);
            NewAddAutoWindowOpen = new LyambdaCommand(OpenAddAutoWindowCommand.OpenNewAddAutoWindowExecuted, OpenAddAutoWindowCommand.OpenNewAddAutoWindowCanExecute);
            NewAddClientWindowOpen = new LyambdaCommand(OpenAddClientWindowCommand.OpenNewAddClientWindowExecuted, OpenAddClientWindowCommand.OpenNewAddClientWindowCanExecute);
            ChooseClientWindowOpen = new LyambdaCommand(OpenActualListOfClientsCommand.OpenActualListOfClientsExecute, OpenActualListOfClientsCommand.OpenActualListOfClientsCanExecute);
            ChooseCartWindowOpen = new LyambdaCommand(OpenActualListOfCarsCommand.OpenActualListOfCarssExecute, OpenActualListOfCarsCommand.OpenActualListOfCarsCanExecute);
            AddNewOrderCommand = new LyambdaCommand(AddNewOrderToDB.AddNewOrderToDBExecuted, AddNewOrderToDB.AddNewOrderToDBCanExecute);
            AddNoteFileToList();
            AddNoteDel += AddNoteFileToList;
            WritePropertyToList();
            WriteClientProperty += WritePropertyToList;
        }
    }
}
