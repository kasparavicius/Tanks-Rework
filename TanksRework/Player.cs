using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TanksRework
{
    class Player
    {
        public Object _id { get; set; }
        public int pozicijax { get; set; }
        public int pozicijay { get; set; }
        public string pavadinimas { get; set; }
        public int metai { get; set; }

        public Player()
        {
            _id = 0;
            pozicijax = 0;
            pozicijay = 0;
            pavadinimas = "";
            metai = 0;
        }
    }
}
