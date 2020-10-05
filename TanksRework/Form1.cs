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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        Player zaidejas = new Player();

        static HttpClient client = new HttpClient();

        private string getUrl = "https://localhost:44356/tankas/details/";
        private string postUrl = "https://localhost:44356/tankas/CreateTank";
        private string locationUrl = "https://localhost:44356/tankas/ChangeLocation";
        private string removeUrl = "https://localhost:44356/tankas/Remove";

        //private string playerId = "";


        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 20;
            dataGridView1.ColumnCount = 20;
            zaidejas = getPlayerDetails("7x6s7vs5adns84au9ypkg5d6");
            IRestClient restClient = new RestClient();

            //Getas
            IRestRequest restRequest = new RestRequest(getUrl + "7x6s7vs5adns84au9ypkg5d6");
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
            zaidejas.metai = 8888;
            zaidejas.pavadinimas = "ParduoduAscona";
            zaidejas.pozicijax = 5;
            zaidejas.pozicijay = 5;

            //Postas
            IRestRequest request = new RestRequest()
            {
                Resource = postUrl
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            request.AddJsonBody(zaidejas);

            IRestResponse<string> response = restClient.Post<string>(request);
            zaidejas._id = response.Data;
            //zaidejas._id = playerId;
            label2.Text = zaidejas._id;

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // this.Hide();
            removePlayer();
            e.Cancel = true;
            this.Close();

        }


        /// <summary>
        /// returns details of given player
        /// </summary>
        /// <param name="id">player id</param>
        /// <returns></returns>
        private Player getPlayerDetails(string id)
        {
            IRestClient restClient = new RestClient();
      
            IRestRequest restRequest = new RestRequest(getUrl + id);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<Player> restResponse = restClient.Get<Player>(restRequest);

            if (restResponse.IsSuccessful)
            {
                Player unit = new Player(
                    restResponse.Data._id, 
                    restResponse.Data.pozicijax, 
                    restResponse.Data.pozicijay,
                    restResponse.Data.pavadinimas, 
                    restResponse.Data.metai);

                return unit;
            }
            else
            {
                label1.Text = restResponse.ErrorMessage;
            }

            return null;
        }

        private void updatePlayerDetails()
        {
            IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest()
            {
                Resource = locationUrl + "/" + zaidejas._id
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(zaidejas);

            IRestResponse response = restClient.Patch(request);
        }

        //Remove on close
        private void removePlayer()
        {
            IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest()
            {
                Resource = removeUrl + "/" + zaidejas._id
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");

            IRestResponse response = restClient.Delete(request);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // up
        private void button3_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijay += 1;
            updatePlayerDetails();
        }
        //left
        private void button2_Click(object sender, EventArgs e)
        {
            if (zaidejas.pozicijax > 0)
            {
                zaidejas.pozicijax -= 1;
            }
            updatePlayerDetails();

        }
        //right
        private void button1_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijax += 1;
            updatePlayerDetails();

        }
        //down
        private void button4_Click(object sender, EventArgs e)
        {
            zaidejas.pozicijay -= 1;
            updatePlayerDetails();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //update button
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            removePlayer();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
