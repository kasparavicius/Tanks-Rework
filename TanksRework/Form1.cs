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
using Microsoft.VisualBasic;
using RestSharp;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        List<Player> enemies = new List<Player>();
        List<Player> enemiesold = new List<Player>();
        Player zaidejas = new Player();

        static HttpClient client = new HttpClient();

        private string getUrl = "https://localhost:44356/tankas/details/";
        private string getEnemies = "https://localhost:44356/tankas/detailsofother/";

        private string postUrl = "https://localhost:44356/tankas/CreateTank";
        private string locationUrl = "https://localhost:44356/tankas/ChangeLocation";
        private string removeUrl = "https://localhost:44356/tankas/Remove";

        //private string playerId = "";


        public Form1()
        {
            this.ControlBox = false;
            InitializeComponent();
            dataGridView1.RowCount = 18;
            dataGridView1.ColumnCount = 25;
            //zaidejas = getPlayerDetails("7x6s7vs5adns84au9ypkg5d6");
            //IRestClient restClient = new RestClient();

            ////Getas
            //IRestRequest restRequest = new RestRequest(getUrl + "7x6s7vs5adns84au9ypkg5d6");
            //restRequest.AddHeader("Accept", "application/json");
            //IRestResponse<Player> restResponse = restClient.Get<Player>(restRequest);

            //if (restResponse.IsSuccessful)
            //{
            //    label1.Text = restResponse.Data.pavadinimas;
            //}
            //else
            //{
            //    label1.Text = restResponse.ErrorMessage;
            //}


            //////Tankiukas
            //zaidejas.metai = 8888;
            //zaidejas.pavadinimas = "ParduoduAscona";
            //zaidejas.pozicijax = 5;
            //zaidejas.pozicijay = 5;

            ////Postas
            //IRestRequest request = new RestRequest()
            //{
            //    Resource = postUrl
            //};

            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "application/xml");
            //request.AddJsonBody(zaidejas);

            //IRestResponse<string> response = restClient.Post<string>(request);
            //zaidejas._id = response.Data;
            ////zaidejas._id = playerId;
            //label2.Text = zaidejas._id;
            //DisplayPlayer(100, 100);

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
               // label1.Text = restResponse.ErrorMessage;
            }

            return null;
        }

        /// <summary>
        /// returns details of enemies
        /// </summary>
        /// <param name="id">player id</param>
        /// <returns></returns>
        private List<Player> getEnemiesDetails(string id)
        {
            IRestClient restClient = new RestClient();

            IRestRequest restRequest = new RestRequest(getEnemies + id);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<Player>> restResponse = restClient.Get<List<Player>>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                // label1.Text = restResponse.ErrorMessage;
            }

            return null;
        }
        private void updatePlayerDetails()
        {
            updateEnemiesDetails();
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

        private void updateEnemiesDetails()
        {

            enemies = getEnemiesDetails(zaidejas._id);
            DisplayEnemies(enemies, enemiesold);
            enemiesold = enemies;
        }

        private void DisplayEnemies(List<Player> naujas, List<Player> senas)
        {

            Bitmap img = (Bitmap)Bitmap.FromFile("assets\\tankas2d.png");
            Bitmap newImage = new Bitmap(img, 20, 20);
            DataGridViewImageCell icell = new DataGridViewImageCell();
            icell.Value = newImage;
            string empty = "";

            if (senas.Count <= 1)
            {
                foreach (var vienas in senas)
                {
                    dataGridView1[vienas.pozicijax, vienas.pozicijay].Value = new Bitmap(1, 1);
                }
            }

            foreach (var vienas in naujas)
            {
                dataGridView1[vienas.pozicijax, vienas.pozicijay] = icell;

            }       

           

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

        private void DisplayPlayer(int senasx, int senasy)
        {

            Bitmap img = (Bitmap) Bitmap.FromFile("assets\\tankas2d.png");
            Bitmap newImage = new Bitmap(img, 20, 20);
            DataGridViewImageCell icell = new DataGridViewImageCell();
            icell.Value = newImage;
            string empty = "";
            
            if (senasx < 100 && senasy < 100)
            {
                dataGridView1[senasx, senasy].Value = new Bitmap(1, 1);

                dataGridView1[zaidejas.pozicijax, zaidejas.pozicijay] = icell;
            }
            else dataGridView1[zaidejas.pozicijax, zaidejas.pozicijay] = icell;

        }

        private void dataGridView1_CellFormatting(object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            String value = e.Value as string;
            if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))
            {
                e.Value = e.CellStyle.NullValue;
                e.FormattingApplied = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // up
        private void button3_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicijax;
            int senasy = zaidejas.pozicijay;
            if (senasy > 0)
            {
                zaidejas.pozicijay -= 1;
                updatePlayerDetails();
                DisplayPlayer(senasx, senasy);
            }
            
        }
        //left
        private void button2_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicijax;
            int senasy = zaidejas.pozicijay;
            if (zaidejas.pozicijax > 0)
            {
                zaidejas.pozicijax -= 1;
                updatePlayerDetails();
                DisplayPlayer(senasx, senasy);
            }
            
        }
        //right
        private void button1_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicijax;
            int senasy = zaidejas.pozicijay;
            if (senasx < 24)
            {
                zaidejas.pozicijax += 1;
                updatePlayerDetails();
                DisplayPlayer(senasx, senasy);
            }
            
        }
        //down
        private void button4_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicijax;
            int senasy = zaidejas.pozicijay;
            if (senasy < 17)
            {
                zaidejas.pozicijay += 1;
                updatePlayerDetails();
                DisplayPlayer(senasx, senasy);
            }
            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IRestClient restClient = new RestClient();

            if (textBox2.Text != null)
            {
                Random rnd = new Random();
                zaidejas.metai = 1998;
                zaidejas.pavadinimas = textBox2.Text;
                zaidejas.pozicijax = rnd.Next(1, 15);
                zaidejas.pozicijay = rnd.Next(1, 15);

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
                DisplayPlayer(100, 100);
            }
        }
    }
}
