using DiplomProject.ViewModels.Base;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
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
            this.MainModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        }

        public MainWindowViewModel()
        {
            ShowStats();
        }
        
    }
}
