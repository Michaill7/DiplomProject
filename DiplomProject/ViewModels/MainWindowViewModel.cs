using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.Models;
using DiplomProject.ViewModels.Base;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private List<string> tablesList;
        public List<string> TablesList 
        {
            get => tablesList;
            set 
            {
                tablesList = value;
                OnPropertyChange();
            }
        }


        private string currentListItem;
        public string CurrentListItem 
        {
            get => currentListItem;
            set 
            {
                currentListItem = value;
                OnPropertyChange();

                var LocalActualList = DataBaseClassWorker.StatusCreater(currentListItem);

                var LocalActualListForShow = new List<string>() { };
                for (int i = 0; i < LocalActualList[0].Count; i++)
                {
                    LocalActualListForShow.Add(LocalActualList[0][i] + "/" + LocalActualList[1][i] + "/" + LocalActualList[2][i] + "/" + LocalActualList[3][i]);
                }
                ActualList = LocalActualListForShow;
            }
        }

        private List<string> actualList;
        public List<string> ActualList 
        {
            get => actualList;
            set 
            {
                
                actualList = value;
                OnPropertyChange();
            }
        }

        private int selectedItemInList;
        public int SelectedItemInList 
        {
            get => selectedItemInList;
            set 
            {
                selectedItemInList = value;
                OnPropertyChange();
                ActualDataGridData = DataBaseClassWorker.ShowDataToDataGrid(CurrentListItem, value+1);
                
                
            }
        }

        private DataTable actualDataGridData;
        public DataTable ActualDataGridData 
        {
            get => actualDataGridData;
            set 
            {
                actualDataGridData = value;
                OnPropertyChange();
            }
        }

        private PlotModel mainModel;
        public PlotModel MainModel
        {
            get => mainModel;
            set 
            {
                mainModel = value;
                OnPropertyChange();
            }
                
        }

        public void ShowStats() 
        {
            this.MainModel = new PlotModel { Title = "Статистика доходов и расходов" };
            this.MainModel.Axes.Add(new DateTimeAxis {Position = AxisPosition.Bottom });
            this.MainModel.Axes.Add(new LinearAxis {Position = AxisPosition.Left });
            var pointLineSales = new LineSeries
            {
                Color = OxyColor.FromRgb(0, 255, 0),
                Title = "Измеряемая величина"
            };

            var pointLinePurchase = new LineSeries
            {
                Color = OxyColor.FromRgb(255, 0, 0),
                Title = "Измеряемая величина"
            };

            var a = DataBaseClassWorker.ShowAccountingSales();
            var b = DataBaseClassWorker.ShowAccountingPurchase();
            for (int i = 0; i < a.Count; i++)
            {
                pointLineSales.Points.Add(new DataPoint(TimeSpanAxis.ToDouble(a[i].SaleDate), a[i].SalePrice));
                pointLinePurchase.Points.Add(new DataPoint(TimeSpanAxis.ToDouble(b[i].PurchaseDate), b[i].PurchasePrice));
            }

            this.MainModel.Series.Add(pointLineSales);
            this.MainModel.Series.Add(pointLinePurchase);
        }



        public ICommand OpenOfferWindow { get; }

        public MainWindowViewModel()
        {
            ShowStats();
            TablesList = DataBaseClassWorker.Tables();
            OpenOfferWindow = new LyambdaCommand(OpenOfferWindowCommand.OpenOfferWindowExecuted, OpenOfferWindowCommand.OpenOfferWindowCanExecute);
        }
        
    }
}
