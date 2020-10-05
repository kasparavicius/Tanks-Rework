using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TanksRework
{
    class Player
    {
        public string _id { get; set; }
        public int pozicijax { get; set; }
        public int pozicijay { get; set; }
        public string pavadinimas { get; set; }
        public int metai { get; set; }

        public Player()
        {
            _id = "";
            pozicijax = 0;
            pozicijay = 0;
            pavadinimas = "";
            metai = 0;
        }

        public Player(string _id, int pozicijax, int pozicijay, string pavadinimas, int metai)
        {
            this._id = _id;
            this.pozicijax = pozicijax;
            this.pozicijay = pozicijay;
            this.pavadinimas = pavadinimas;
            this.metai = metai;
        }
    }
}
