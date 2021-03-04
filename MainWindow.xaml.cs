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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public testEntities db = new testEntities();
        public static Users user = new Users();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_btn_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != "" && password.Password != "")
            {
                user = db.Users.Where(s => s.username == username.Text && s.password == password.Password).SingleOrDefault();
                if (user != null)
                {
                    TodoList.tasks task = new TodoList.tasks();
                    task.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا يوجد شخص بهذا الاسم والباسورد");
                }
            }
            else{
                    MessageBox.Show("برجاء ادخال جميع البيانات");

            }
                       
            
        }
    }
}
