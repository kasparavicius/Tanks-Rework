using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        Player zaidejas = new Player();
        static string eilute = "";
        static HttpClient client = new HttpClient();

        private string getUrl = "https://localhost:44356/tankas/details/dgh13dcmybva4uo3gft2fx3u";
        private string postUrl = "https://localhost:44356/tankas/CreateTank";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 20;
            dataGridView1.ColumnCount = 20;
            
            IRestClient restClient = new RestClient();

            //Getas
            IRestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<Player> restResponse = restClient.Get<Player>(restRequest);

            if (restResponse.IsSuccessful)
            {
                label1.Text = restResponse.Data.pavadinimas;
            }
            else
            {
                label1.Text = restResponse.ErrorMessage;
            }


            //Tankiukas
            Player tankiukas = new Player();
            tankiukas.metai = 1919;
            tankiukas.pavadinimas = "ZaliaSiera";
            tankiukas.pozicijax = 5;
            tankiukas.pozicijay = 5;

            //Postas
            IRestRequest request = new RestRequest()
            {
                Resource = postUrl
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(tankiukas);

            IRestResponse response = restClient.Post(request);
            label1.Text = response.StatusCode.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // up
        private void button3_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijay += 1;
        }
        //left
        private void button2_Click(object sender, EventArgs e)
        {
            if (zaidejas.pozicijax > 0)
            {
                zaidejas.pozicijax -= 1;
            }
        }
        //right
        private void button1_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijax += 1;
        }
        //down
        private void button4_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijay -= 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
