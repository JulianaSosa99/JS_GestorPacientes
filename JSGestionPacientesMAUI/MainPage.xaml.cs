 
using JSGestionPacientesMAUI.Models;
using Newtonsoft.Json;

namespace JSGestionPacientesMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Pacientes(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7046/api/");
            var response=client.GetAsync("jspaciente").Result;
            if (response.IsSuccessStatusCode) {

                var paciente = response.Content.ReadAsStringAsync().Result;
                var pacienteList=JsonConvert.DeserializeObject<List<JSPaciente>>(paciente);
                listView.ItemsSource = pacienteList;    
            }



        }
    }

}
