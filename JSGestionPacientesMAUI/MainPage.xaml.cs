using Android.Webkit;

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
            client.BaseAddress = new Uri("https://udla.brightspace.com/d2l/home");

        }
    }

}
