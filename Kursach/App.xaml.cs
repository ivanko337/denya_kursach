using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kursach.View;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WorkerWindow workerWindow = new WorkerWindow();
            OrdersWindow ordersWindow = new OrdersWindow();
            MenuWindow menuWindow = new MenuWindow();
            CreateOrderWindow createOrderWindow = new CreateOrderWindow();

            try
            {
                workerWindow.Show();
                ordersWindow.Show();
                menuWindow.Show();
                createOrderWindow.Show();
            }
            catch
            {
                Application.Current.Shutdown();
            }
        }
    }
}
