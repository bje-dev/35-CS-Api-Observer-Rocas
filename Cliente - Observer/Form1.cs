using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente___Observer
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly Timer timer = new Timer();

        private Roca rocaObservada = new Roca();
        private IgneasObserver igneaObserver = new IgneasObserver();
        private MetaforicasObserver metaforicaObserver = new MetaforicasObserver();
        private SeridianasObserver seridianaObserver = new SeridianasObserver();

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 2000;
            timer.Tick += async (sender, e) => await ObtenerDatosRoca();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rocaObservada.RegistrarObservador(igneaObserver);
            rocaObservada.RegistrarObservador(metaforicaObserver);
            rocaObservada.RegistrarObservador(seridianaObserver);

            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            rocaObservada.QuitarObservador(igneaObserver);
            rocaObservada.QuitarObservador(metaforicaObserver);
            rocaObservada.QuitarObservador(seridianaObserver);
        }

        private async Task ObtenerDatosRoca()
        {
            try
            {
                string apiUrl = "http://localhost:5147/api/Roca/roca";
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var objetoApi = JsonConvert.DeserializeObject<Roca>(apiResponse);
                    MostrarResultado(objetoApi.Nombre.ToString(), objetoApi.Tipo.ToString(), objetoApi.Origen.ToString(), objetoApi.Tamaño.ToString(), objetoApi.Lugar.ToString());
                }
                else
                {
                    MessageBox.Show($"Error en la solicitud. Código de estado: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}");
            }
        }

        public void MostrarResultado(string nombre, string tipo, string origen, string tamaño, string lugar)
        {

            textBox1.Text = nombre;
            textBox2.Text = tipo;
            textBox3.Text = origen;
            textBox4.Text = tamaño;
            textBox5.Text = lugar;


            rocaObservada.Nombre = nombre;
            rocaObservada.Tipo = tipo;
            rocaObservada.Origen = origen;
            rocaObservada.Tamaño = tamaño;
            rocaObservada.Lugar = lugar;

            rocaObservada.SomeBusinessLogic();

        }
    }
}
