using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Web.Script.Serialization;

namespace WpfClinetForWeb.Api
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


        private void buttonname_Click(object sender, RoutedEventArgs e)
        {
            // Sarqel em HttpClient 
            HttpClient client = new HttpClient();

            // Get harcum em uxarkel Web.Api-in
            HttpResponseMessage responce = client.GetAsync(@"http://localhost:62430/api/main").Result; // ushadir em, im api-i hascen em drel :)
            //// Responce-ov harcum e gnum Web.Api-i Get(im depqum GetNumber) funkciayin


            // message-i mej kardum em patasxan@
            string message = responce.Content.ReadAsStringAsync().Result;

            // Qani vor json formatova ekel, Deserialize em anum
            JavaScriptSerializer text = new JavaScriptSerializer();
            string content = text.Deserialize<string>(message);

            // U adren haskanali formatov dnum em textblocki mej
            textblockname.Text = content;
        }
    }
}
