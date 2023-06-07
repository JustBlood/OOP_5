using SeventhPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SixthPractice
{
    /// <summary>
    /// Логика взаимодействия для ThirdTask.xaml
    /// </summary>
    public partial class ThirdTask : Window
    {
        private Dictionary<string, GetString> buttonNameToMethod = new Dictionary<string, GetString>();
        public event GetString task;
        public ThirdTask()
        {
            InitializeComponent();

            buttonNameToMethod["file"] = InfoGetter.GetStringFromFile;
            buttonNameToMethod["db"] = InfoGetter.GetStringFromDb;
            buttonNameToMethod["internet"] = InfoGetter.GetStringFromSite;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            try
            {
                if (button.Name.Equals("file"))
                {
                    task.Invoke(path.Text);
                }
                if (button.Name.Equals("db"))
                {
                    task.Invoke(connString.Text);
                }
                task.Invoke(url.Text);
            }
            catch { MessageBox.Show("Добавьте в событие методы"); }

        }

        private void addToEvent_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            if (button.Name.ToString().Contains("File")
                && !task.GetInvocationList().Contains(buttonNameToMethod["file"]))
            {
                task += buttonNameToMethod["file"];
            }
            else if (button.Name.ToString().Contains("Db")
                && !task.GetInvocationList().Contains(buttonNameToMethod["db"]))
            {
                task += buttonNameToMethod["db"];
            }
            else if (button.Name.ToString().Contains("Internet")
                && (task is null || task is not null && !task.GetInvocationList().Contains(buttonNameToMethod["internet"])))
            {
                task += buttonNameToMethod["internet"];
            }
            
        }

        private void delFromEvent_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString().Contains("file")
                && task.GetInvocationList().Contains(buttonNameToMethod["file"]))
            {
                task -= buttonNameToMethod["file"];
            }
            else if (button.Content.ToString().Contains("db")
                && task.GetInvocationList().Contains(buttonNameToMethod["db"]))
            {
                task -= buttonNameToMethod["db"];
            }
            else if (button.Content.ToString().Contains("internet")
                && task.GetInvocationList().Contains(buttonNameToMethod["internet"]))
            {
                task -= buttonNameToMethod["internet"];
            }
        }
    }
}
