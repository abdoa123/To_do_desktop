using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TodoList
{
    /// <summary>
    /// Interaction logic for tasks.xaml
    /// </summary>
    public partial class tasks : Window
    {
        public testEntities db = new testEntities();
        public tasks()
        {
            InitializeComponent();
        }


        private void RadGridView_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();

        }
        public void loadData()
        {
           var obj = db.Users.Join(
                db.tasks,
                us=>us.id,
                ta =>ta.user_id,
                (us,ta) => new 
                {
                    taskName = ta.task_name,
                    inf = ta.inf,
                    isDone = ta.isDone,
                    date = ta.date,
                    priority = ta.priority,
                    name = us.username
                }
                ).ToList();
           tasksview.ItemsSource = obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TName.Text != "" && pr.SelectedIndex != -1 && dp.Text != "" && info.Text != "")
            {
                tasks task = new tasks();
                task.task_name = TName.Text;
                task.priority = pr.SelectedIndex.ToString();
                task.date = (DateTime.Parse(dp.Text));
                task.inf = info.Text;
                task.user_id = MainWindow.user.id;
                task.isDone = false;
                db.tasks.Add(task);
                db.SaveChanges();
                loadData();

            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
