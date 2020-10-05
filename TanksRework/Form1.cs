using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksRework
{
    public partial class Form1 : Form
    {
        Player zaidejas = new Player();
        static HttpClient client = new HttpClient();


        public Form1()
        {
            client.BaseAddress = new Uri("http://localhost:44356/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            dataGridView1.RowCount = 20;
            dataGridView1.ColumnCount = 20;
            zaidejas = GetProductAsync("dgh13dcmybva4uo3gft2fx3u");
            label1.Text = zaidejas.pavadinimas; 
            
        }

        static async Task<Player> GetProductAsync(string id)
        {
            Player zzaidejas = new Player();
            string response = await client.GetStringAsync($"tankas/details/{id}");
            zzaidejas.pavadinimas = response;
            return zzaidejas;
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
