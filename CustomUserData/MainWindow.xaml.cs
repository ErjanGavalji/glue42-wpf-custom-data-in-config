using System;
using System.Windows;
using Tick42;

namespace CustomUserData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Glue42 glue;
        private string appName = "wpf-custom-user-context-data";

        public MainWindow()
        {
            InitializeComponent();
            //Initialize Glue42 and register the current app:
            this.glue = new Glue42();
            this.glue.Initialize(appName);

            this.glue.AppManager.ApplicationAdded += AppManager_ApplicationAdded;
        }

        private void AppManager_ApplicationAdded(object sender, Tick42.AppManager.AppManagerApplicationEventArgs e)
        {
            Action action = () => {
                if (e.Application.Name == this.appName)
                {
                    lblGroup.Content = e.Application.UserProperties["group"];
                }
            };

            if (!CheckAccess())
            {
                Dispatcher.BeginInvoke(action, null);
            }
            else
            {
                action();
            }

        }
    }
}
