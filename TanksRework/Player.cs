using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TanksRework
{
    class Player
    {
        public string _id { get; set; }
        public int[] pozicija { get; set; }
        public string pavadinimas { get; set; }
        public int metai { get; set; }

        public Player()
        {
            _id = "";
            pozicija = new int[] { 0, 0 };
            pavadinimas = "";
            metai = 0;
        }

        public Player(string _id, int[] pozicija, string pavadinimas, int metai)
        {
            this._id = _id;
            this.pozicija = pozicija;
            this.pavadinimas = pavadinimas;
            this.metai = metai;
        }
    }
}
