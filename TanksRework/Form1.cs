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
using TanksRework.Classes.AbstractFactory;
using TankaiRework.ER;
using System.Drawing.Text;
using TankaiRework.Commander;
using TanksRework.Classes.Zemelapis;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        Zemelapis zemelapis = new Zemelapis();
        List<Player> enemies = new List<Player>();
        List<Player> enemiesold = new List<Player>();
        Player zaidejas = new Player();

        Transportas playeris;// = new TransportasFactory().CreateTransportas(1, "nuva");
        List<Transportas> priesai;

        //Commander initialize
        //private ICommand command;
        private List<ICommand> commandsStack;

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

            commandsStack = new List<ICommand>();


            timer1.Interval = 100;
            timer1.Start();

            timer2.Interval = 100;
            timer2.Start();

            //Load stichijos
            StichijosCache Stichijos = new StichijosCache();
            Stichijos.loadCache();

            //Kulkos test
            Ginklas ginklas = new Ginklas(10, 10);
            /*richTextBox1.Text = 
                $"Simple zala {ginklas.ZalaSimple()}\n" +
                $"Fire zala {ginklas.ZalaFire()}\n" +
                $"Explosive zala {ginklas.ZalaExplosive()}\n" +
                $"Both zala {ginklas.ZalaFireAndExplosive()}\n";*/
            richTextBox1.Text = $"Simple zala {ginklas.GetZala()}\n";
            ginklas.AddPowerUp(1);
            richTextBox1.Text += $"Fire zala {ginklas.GetZala()}\n";
            ginklas.RemovePowerUps();
            ginklas.AddPowerUp(2);
            richTextBox1.Text += $"Explosion zala {ginklas.GetZala()}\n";
            ginklas.AddPowerUp(1);
            richTextBox1.Text += $"Both zala {ginklas.GetZala()}\n";
            ginklas.RemovePowerUps();
            ginklas.AddPowerUp(1);
            ginklas.AddPowerUp(1);
            richTextBox1.Text += $"Double fire zala {ginklas.GetZala()}\n";
            ginklas.RemovePowerUps();
            ginklas.AddPowerUp(1);
            ginklas.AddPowerUp(1);
            ginklas.AddPowerUp(2);
            richTextBox1.Text += $"Double fire + explosion zala {ginklas.GetZala()}\n";


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
            GetMap();
            

            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);

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
            //updateEnemiesDetails();
            /*IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest()
            {
                Resource = locationUrl + "/" + zaidejas._id
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(zaidejas);

            IRestResponse response = restClient.Patch(request);*/
            richTextBox1.Text = $"Naujos koord = {playeris.positionx}, {playeris.positiony}\n";
            panel1.Invalidate();
        }

        private void updateEnemiesDetails()
        {

            enemies = getEnemiesDetails(zaidejas._id);
            //DisplayEnemies(enemies, enemiesold);
            enemiesold = enemies;
        }

        /*private void DisplayEnemies(List<Player> naujas, List<Player> senas)
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
        }*/

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

        /*private void DisplayPlayer()
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

        }*/

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            commandsStack.Add(new MoveUp(playeris));
            //updatePlayerDetails();
        }
        //left
        private void button2_Click(object sender, EventArgs e)
        {
            commandsStack.Add(new MoveLeft(playeris));
            //updatePlayerDetails();
        }
        //right
        private void button1_Click(object sender, EventArgs e)
        {
            commandsStack.Add(new MoveRight(playeris));
            //updatePlayerDetails();
            
        }
        //down
        private void button4_Click(object sender, EventArgs e)
        {
            commandsStack.Add(new MoveDown(playeris));
            //updatePlayerDetails();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Nuskaitom visus esamus priesus
        private void button6_Click(object sender, EventArgs e)
        {
            UpdateEnemyList();
        }

        private void LoadEnemyList()
        {
            restas.UseNewtonsoftJson();
            IRestRequest restRequest = new RestRequest("https://localhost:44356/Tankas/GetEnemyList/" + playeris.getId());
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<Transportas>> restResponse = restas.Get<List<Transportas>>(restRequest);

            restResponse.Content = restResponse.Content.Replace("TankaiServer", "TanksRework");

            priesai = JsonConvert.DeserializeObject<List<Transportas>>(restResponse.Content, serializerSettings);
            playeris.observers = new List<IObserver>();
            //var priesopos = restResponse.Content[0];
            priesai.ForEach(p =>
            {
                playeris.prideti(p);
            });
            //label1.Text = restResponse.Content;

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

        private void UpdateEnemyList()
        {
            //playeris = new TransportasFactory().CreateTransportas(comboBox1.SelectedIndex + 1, textBox2.Text);

            restas.UseNewtonsoftJson();

            //Postinam savo pozicija
            IRestRequest request = new RestRequest()
            {
                Resource = "https://localhost:44356/Tankas/Position/"
            };

            var test = JsonConvert.SerializeObject(playeris, Formatting.Indented, serializerSettings);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.AddJsonBody(test);
            request.AddParameter("application/json", test, ParameterType.RequestBody);
            restas.Post<string>(request);
            //IRestResponse<string> response = restas.Post<string>(request);


            //Gaunam priesu sarasa
            IRestRequest restRequest = new RestRequest("https://localhost:44356/Tankas/GetEnemyList/" + playeris.getId());
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<List<Transportas>> restResponse = restas.Get<List<Transportas>>(restRequest);

            restResponse.Content = restResponse.Content.Replace("TankaiServer", "TanksRework");

            var temp = JsonConvert.DeserializeObject<List<Transportas>>(restResponse.Content, serializerSettings);

            //Pridedam jei atsirado nauju
            List<Transportas> nauji = new List<Transportas>();
            temp.ForEach(t =>
            {
                int i = 0;
                priesai.ForEach(p =>
                {
                    if (t.getId() == p.getId())
                        i++;
                });
                if (i == 0)
                    nauji.Add(t);
            });
            nauji.ForEach(n =>
            {
                priesai.Add(n);
                playeris.prideti(priesai.Last());
            });

            //Ismetam jei kazkas isejo
            List<Transportas> seni = new List<Transportas>();
            priesai.ForEach(p =>
            {
                int i = 0;
                temp.ForEach(t =>
                {
                    if (p.getId() == t.getId())
                        i++;
                });
                if (i == 0)
                    seni.Add(p);
            });
            seni.ForEach(s =>
            {
                var ind = priesai.FindIndex(a => a.getId() == s.getId());
                playeris.pasalinti(priesai[ind]);
                priesai.RemoveAt(ind);
            });
            
            //var matches = temp.Where(p => p.Name == nameToExtract);

            playeris.pranesti(temp);
        }

        private void Disconnect()
        {
            restas.UseNewtonsoftJson();

            //Ka atjungt?
            IRestRequest request = new RestRequest()
            {
                Resource = "https://localhost:44356/Tankas/Disconnect/"
            };

            var test = JsonConvert.SerializeObject(playeris, Formatting.Indented, serializerSettings);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.AddJsonBody(test);
            request.AddParameter("application/json", test, ParameterType.RequestBody);
            restas.Post<string>(request);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            if (playeris != null)
                Disconnect();
            //removePlayer();
            //Disconnect padaryti...
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //Connect button
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

                LoadEnemyList();
            }
        }

        public void GetMap()
        {
            restas.UseNewtonsoftJson();
            IRestRequest restRequest = new RestRequest("https://localhost:44356/api/zemelapis/2");
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<int[,]> restResponse = restas.Get<int[,]>(restRequest);

            restResponse.Content = restResponse.Content.Replace("TankaiServer", "TanksRework");

            zemelapis.matrix = JsonConvert.DeserializeObject<int[,]>(restResponse.Content, serializerSettings);

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

            commandsStack.ForEach(k =>
            {
                k.Execute();
            });
            commandsStack.Clear();
            if(playeris != null)
                updatePlayerDetails();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (playeris != null)
                UpdateEnemyList();
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.");
                        e.Handled = true;
                        break;
                }
            }*/

            //
            if ((Char.ToLower(e.KeyChar) == Char.ToLower((char)Keys.W) || Char.ToLower(e.KeyChar) == Char.ToLower((char)Keys.S) ||
                Char.ToLower(e.KeyChar) == Char.ToLower((char)Keys.A) || Char.ToLower(e.KeyChar) == Char.ToLower((char)Keys.D)) && !(playeris is null))
            {
                //MessageBox.Show($"Blet primaigei nesamoniu");
                //e.Handled = true;

                switch (Char.ToLower(e.KeyChar))
                {
                    case 'w':
                        commandsStack.Add(new MoveUp(playeris));
                        break;
                    case 's':
                        commandsStack.Add(new MoveDown(playeris));
                        break;
                    case 'a':
                        commandsStack.Add(new MoveLeft(playeris));
                        break;
                    case 'd':
                        commandsStack.Add(new MoveRight(playeris));
                        break;
                    default:
                        break;
                }
                //command.Execute();
                //updatePlayerDetails();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.Red, 10, 10, 100, 75);
            var plotis = panel1.Width;
            var aukstis = panel1.Height;
            var gridSize = 15;
            var langelioPlotis  = (float)plotis  / gridSize;
            var langelioAukstis = (float)aukstis / gridSize;
            var currLangX = 2;
            var currLangY = 2;
            for (int i = 1; i < gridSize; i++)
            {
                g.DrawLine(Pens.Red, langelioPlotis * i, 0, langelioPlotis * i, aukstis);
                g.DrawLine(Pens.Red, 0, langelioAukstis * i, plotis, langelioAukstis * i);
            }
            g.FillEllipse(Brushes.Blue, currLangX * langelioPlotis, currLangY * langelioAukstis, langelioPlotis, langelioAukstis);
            //currLangX++;
            Image tankasImg = new Bitmap("assets\\tankas2d.png");
            Image priesasImg = new Bitmap("assets\\tankas2denemy.png");

            if(playeris != null)
                g.DrawImage(tankasImg, playeris.positionx * langelioPlotis + 1, playeris.positiony * langelioAukstis + 1, langelioPlotis - 2, langelioAukstis - 2);

            if (!(priesai is null) && priesai.Count > 0)
            {
                priesai.ForEach(pries =>
                {
                    g.DrawImage(priesasImg, pries.positionx * langelioPlotis + 1, pries.positiony * langelioAukstis + 1, langelioPlotis - 2, langelioAukstis - 2);
                });
            }
            if (playeris != null)
            {

                for (int i = 0; i < zemelapis.sizeX; i++)
                {
                    for (int j = 0; j < zemelapis.sizeY; j++)
                    {
                        switch (zemelapis.matrix[i, j])
                        {
                            case 1:
                                g.FillEllipse(Brushes.Green, i * langelioPlotis, j * langelioAukstis, langelioPlotis, langelioAukstis);
                                break;
                            case 2:
                                g.FillEllipse(Brushes.Blue, i * langelioPlotis, j * langelioAukstis, langelioPlotis, langelioAukstis);
                                break;
                            case 3:
                                g.FillEllipse(Brushes.Gray, i * langelioPlotis, j * langelioAukstis, langelioPlotis, langelioAukstis);
                                break;
                            case 4:
                                g.FillEllipse(Brushes.Yellow, i * langelioPlotis, j * langelioAukstis, langelioPlotis, langelioAukstis);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

    }
}
