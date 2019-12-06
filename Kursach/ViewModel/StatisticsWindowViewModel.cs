using Kursach.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Kursach.ViewModel
{
    public class StatisticsWindowViewModel : ViewModelBase
    {
        private string excelFilePath;

        private BaseCommand command;
        public ICommand CreateStatisticsCommand
        {
            get
            {
                if (command == null)
                {
                    command = new BaseCommand(CreateStatistics, null);
                }
                return command;
            }
        }

        private List<Order> GetSatistics(DateTime startDate, DateTime endDate)
        {
            using (KursachDBContext context = new KursachDBContext())
            {
                return context.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
            }
        }

        private void WriteDataToExcel(List<Order> orders)
        {
            string sheetName = "";

            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            _Workbook oWB = oXL.Workbooks.Open(excelFilePath);
            _Worksheet oSheet = string.IsNullOrEmpty(sheetName) ? (_Worksheet)oWB.ActiveSheet : (_Worksheet)oWB.Worksheets[sheetName];

            oSheet.Cells.ClearContents();

            oSheet.Cells[1, 1] = "Id";
            oSheet.Cells[1, 2] = "Total";
            oSheet.Cells[1, 3] = "Discount";
            oSheet.Cells[1, 4] = "Order date";

            int i = 2;
            foreach (Order order in orders)
            {
                oSheet.Cells[i, 1] = order.Id.ToString();
                oSheet.Cells[i, 2] = order.Total.ToString();
                oSheet.Cells[i, 3] = order.Discount.ToString();
                oSheet.Cells[i, 4] = order.OrderDate.ToString();
                ++i;
            }

            oWB.Save();
            if (oWB != null)
                oWB.Close();
        }

        public void CreateStatistics(object parameter)
        {
            object[] parameters = (object[])parameter;
            DateTime fDate = ((DateTime?)parameters[0]).Value;
            DateTime sDate = ((DateTime?)parameters[1]).Value;

            try
            {
                List<Order> orders = GetSatistics(fDate, sDate);

                OpenFileDialog dialog = new OpenFileDialog();
                //dialog.Filter = "Excel files (*.xls|*.xlsx)|*.xls;*.xlsx";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    excelFilePath = dialog.FileName;
                }

                WriteDataToExcel(orders);
                System.Windows.MessageBox.Show("Статистика сохранена");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
