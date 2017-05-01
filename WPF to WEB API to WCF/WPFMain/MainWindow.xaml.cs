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
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;

namespace WPFMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<Person> listperson;

        private void GetName_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            
            HttpResponseMessage responce = client.GetAsync(@"http://localhost:57393/api/main").Result;
           
            string msg = responce.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer jss = new JavaScriptSerializer();

            listperson = jss.Deserialize<ObservableCollection<Person>>(msg);

            personlistname.Items.Clear();

            foreach (var item in listperson)
            {
                personlistname.Items.Add(item.ID + ". " + item.Name + "  " + item.Age);
            }
           
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person { ID = int.Parse(textboxID.Text), Name = textboxName.Text, Age = int.Parse(textboxAge.Text) };
            
            HttpClient client = new HttpClient();
            
            HttpResponseMessage responce = client.PostAsync(@"http://localhost:57393/api/main", person, new JsonMediaTypeFormatter()).Result;

            string msg = responce.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer jss = new JavaScriptSerializer();

            MessageBox.Show(jss.Deserialize<string>(msg));
        }


        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
       
    }
}
