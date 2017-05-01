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

        // Sa personneri lista, vori mej lcvuma WCF-ic ekac personner@
        private ObservableCollection<Person> listperson;

        //Get harcman ButtonClick-na
        private void GetName_Click(object sender, RoutedEventArgs e)
        {
            // Sarqum em HttpClient 
            HttpClient client = new HttpClient();

            // Responce-ov harcum e gnum Web.Api-i Get funkciayin
            HttpResponseMessage responce = client.GetAsync(@"http://localhost:57393/api/main").Result; // ushadir em, im api-i hascen em drel 

            // msg-i mej kardum em patasxan@
            string msg = responce.Content.ReadAsStringAsync().Result;

            // Qani vor json formatova ekel patasxan@
            //sarqum enq deserialaiser u patasxan@ darcnum enq ObservableCollection<Person>
            JavaScriptSerializer jss = new JavaScriptSerializer();

            listperson = jss.Deserialize<ObservableCollection<Person>>(msg);

            // Listbox-i infon jnjum em, vor amen get harcman jamanak popoxvac infon beri
            personlistname.Items.Clear();

            // Stacvac personneri list-ic mez anhrajesht infon lcnum em mer listbox-i mej
            foreach (var item in listperson)
            {
                personlistname.Items.Add(item.ID + ". " + item.Name + "  " + item.Age);
            }

        }

        // Post harcman ButtonClick-na
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //sarqum em ayn person-in, vor@ petqa poxancvi web.api, vorn el` wcf-in
            Person person = new Person { ID = int.Parse(textboxID.Text), Name = textboxName.Text, Age = int.Parse(textboxAge.Text) };

            HttpClient client = new HttpClient();

            // Post harcman het im sarqac personin uxarkum em  web.api
            HttpResponseMessage responce = client.PostAsync(@"http://localhost:57393/api/main", person, new JsonMediaTypeFormatter()).Result;
            //JsonMediaTypeFormatter-@ ashxatuma :)

            // web.api-ic stanum enq patasxan ardyoq Post harcum@ lava gnacel te voch
            string msg = responce.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer jss = new JavaScriptSerializer();

            //patasxan@ messageboxov cuyc em talis
            MessageBox.Show(jss.Deserialize<string>(msg));
        }

        // Person class-na
        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
