using Kursach.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace Kursach.ViewModel
{
    public class StatisticsWindowViewModel : ViewModelBase
    {
        private BaseCommand command;
        public ICommand CreateStatisticsCommand
        {
            get
            {
                if(command == null)
                {
                    command = new BaseCommand(CreateStatistics, null);
                }
                return command;
            }
        }

        public void CreateStatistics(object parameter)
        {
            object[] parameters = (object[])parameter;
            DatePicker fPicker = (DatePicker)parameters[0];
            DatePicker sPicker = (DatePicker)parameters[1];


        }
    }
}
