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
using System.Data.SqlClient;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for DealingWithDatabAse.xaml
    /// </summary>
    public partial class DealingWithDatabAse : Window
    {
        public DealingWithDatabAse()
        {
            InitializeComponent();
            // database connections
            //[connected]
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ititestsd;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Employees");
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr =  cmd.ExecuteReader();
            List<Employee> myemps = new List<Employee>();

            while(dr.Read())
            {
                myemps.Add(new Employee() {ID=int.Parse(dr["ID"].ToString()),FirstName=dr["FirstName"].ToString(),LastName=dr["LastName"].ToString() });
            }
            mylist.ItemsSource =myemps;
            con.Close();
        }

        private void fun(object sender, RoutedEventArgs e)
        {

        }

        private void getcurrentemployee(object sender, SelectionChangedEventArgs e)
        {
            mystack.DataContext= mylist.SelectedItem;
        }
    }
}
