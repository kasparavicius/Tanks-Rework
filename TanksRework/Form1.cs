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
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using Classes;
using Classes.Observer;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        List<Player> enemies = new List<Player>();
        List<Player> enemiesold = new List<Player>();
        Player zaidejas = new Player();

        Transportas playeris;// = new TransportasFactory().CreateTransportas(1, "nuva");
        List<Transportas> priesai;

        static HttpClient client = new HttpClient();
        IRestClient restas = new RestClient();

        JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
    };

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
            dataGridView1.RowCount = 15;
            dataGridView1.ColumnCount = 25;

            timer1.Interval = 500;
            timer1.Start();

            TankasTransportas zaidejas3 = new TankasTransportas("Zaidejas", 100, 10, 5, 5 );

            //zaidejas.atnaujinti("la");
            //Transportas priesas = new TransportasFactory().CreateTransportas(1, "nuva");
            //zaidejas3.prideti(priesas);
            //zaidejas3.pranesti("hello");

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
            //restClient.UseNewtonsoftJson();

            IRestRequest restRequest = new RestRequest(getUrl + id);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<Player> restResponse = restClient.Get<Player>(restRequest);

            if (restResponse.IsSuccessful)
            {
                Player unit = new Player(
                    restResponse.Data._id, 
                    restResponse.Data.pozicija,
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

            Bitmap img = (Bitmap)Bitmap.FromFile("assets\\tankas2denemy.png");
            Bitmap newImage = new Bitmap(img, 20, 20);
            DataGridViewImageCell icell = new DataGridViewImageCell();
            icell.Value = newImage;
            string empty = "";

            if (senas.Count <= 1)
            {
                foreach (var vienas in senas)
                {
                    dataGridView1[vienas.pozicija[0], vienas.pozicija[1]].Value = new Bitmap(1, 1);
                }
            }

            foreach (var vienas in naujas)
            {
                if (dataGridView1[vienas.pozicija[0], vienas.pozicija[1]] != icell)
                {
                    dataGridView1[vienas.pozicija[0], vienas.pozicija[1]] = icell;

                }

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

        private void DisplayPlayer()
        {

            Bitmap img = (Bitmap) Bitmap.FromFile("assets\\tankas2d.png");
            Bitmap newImage = new Bitmap(img, 20, 20);
            DataGridViewImageCell icell = new DataGridViewImageCell();
            icell.Value = newImage;
            string empty = "";

            //if (senasx < 100 && senasy < 100)
            //{
            //dataGridView1[senasx, senasy].Value = new Bitmap(1, 1);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

                dataGridView1[playeris.positionx, playeris.positiony] = icell;
            //}
            //else 
                //dataGridView1[playeris.positionx, playeris.positiony] = icell;

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
            int senasx = zaidejas.pozicija[0];
            int senasy = zaidejas.pozicija[1];
            if (senasy > 0)
            {
                zaidejas.pozicija[1] -= 1;
                updatePlayerDetails();
                //DisplayPlayer(senasx, senasy);
            }
            
        }
        //left
        private void button2_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicija[0];
            int senasy = zaidejas.pozicija[1];
            if (zaidejas.pozicija[0] > 0)
            {
                zaidejas.pozicija[0] -= 1;
                updatePlayerDetails();
                //DisplayPlayer(senasx, senasy);
            }
            
        }
        //right
        private void button1_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicija[0];
            int senasy = zaidejas.pozicija[1];
            if (senasx < 24)
            {
                zaidejas.pozicija[0] += 1;
                updatePlayerDetails();
                //DisplayPlayer(senasx, senasy);
            }
            
        }
        //down
        private void button4_Click(object sender, EventArgs e)
        {
            int senasx = zaidejas.pozicija[0];
            int senasy = zaidejas.pozicija[1];
            if (senasy < 17)
            {
                zaidejas.pozicija[1] += 1;
                updatePlayerDetails();
                //DisplayPlayer(senasx, senasy);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Nuskaitom visus esamus priesus
        private void button6_Click(object sender, EventArgs e)
        {
            restas.UseNewtonsoftJson();
            IRestRequest restRequest = new RestRequest("https://localhost:44356/Tankas/GetEnemyList/" + playeris.getId());
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<Transportas>> restResponse = restas.Get<List<Transportas>>(restRequest);

            restResponse.Content = restResponse.Content.Replace("TankaiServer", "TanksRework");

            var priesai = JsonConvert.DeserializeObject<List<Transportas>>(restResponse.Content, serializerSettings);
            playeris.observers = new List<IObserver>();
            var priesopos = restResponse.Content[0];
            priesai.ForEach(p =>
            {
                playeris.prideti(p);
            });
            label1.Text = restResponse.Content;

            if (restResponse.IsSuccessful)
            {
                //return restResponse.Data;
                priesai = restResponse.Data;
                priesai.ForEach(p =>
                {
                    playeris.prideti(p);
                });
                label1.Text = priesai[0].ToString();
            }
            else
            {
                //label1.Text = restResponse.ErrorMessage;
            }

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
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
            //IRestClient restClient = new RestClient();

            if (textBox2.Text != null)
            {
                /*Random rnd = new Random();
                zaidejas.metai = 1998;
                zaidejas.pavadinimas = textBox2.Text;
                zaidejas.pozicija[0] = rnd.Next(1, 15);
                zaidejas.pozicija[1] = rnd.Next(1, 15);*/

                playeris = new TransportasFactory().CreateTransportas(comboBox1.SelectedIndex+1, textBox2.Text);

                restas.UseNewtonsoftJson();

                //Postas
                IRestRequest request = new RestRequest()
                {
                    Resource = "https://localhost:44356/Tankas/Connect/"
                };

                var test = JsonConvert.SerializeObject(playeris, Formatting.Indented, serializerSettings);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/xml");
                //request.AddJsonBody(test);
                request.AddParameter("application/json", test, ParameterType.RequestBody);

                IRestResponse<string> response = restas.Post<string>(request);
                playeris.setId(response.Data);// = response.Data;
                                              //zaidejas._id = playerId;
                                              //label2.Text = test;
                richTextBox1.Text = JsonConvert.SerializeObject(playeris, Formatting.Indented, serializerSettings);
                //label1.Text = JsonConvert.DeserializeObject<Transportas>(test, serializerSettings).getId();
                //DisplayPlayer(100, 100);

                DisplayPlayer();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         /*   //TO-DO: Get changes from server
            IRestRequest restRequest = new RestRequest("https://localhost:44356/Tankas/GetEnemyList/" + playeris.getId());
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<Transportas>> restResponse = restas.Get<List<Transportas>>(restRequest);

            if (restResponse.IsSuccessful)
            {
                //return restResponse.Data;
                //priesai = restResponse.Data;
                playeris.pranesti(restResponse.Data);
            }
            else
            {
                // label1.Text = restResponse.ErrorMessage;
            }*/
        }
    }
}
