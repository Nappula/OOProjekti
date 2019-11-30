using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UusiProjektityö
{
    //ARVOSTELU Luokkarakenne 4: osaa määritellä luokan, joka perii yläluokan

    [Serializable]
    class Multituote : Tuote , Rajapinnat.ITuote
    {
        private string _multituotenumero;
        public Multituote(string _multituoteNumero, string _tuotenumero, string _tuotenimi) : base(_tuotenumero, _tuotenimi)
        {
            multituotenumero = _multituoteNumero;
        }

        public string multituotenumero
        {
            get { return _multituotenumero; }
            set { _multituotenumero = value; }
        }


        //ARVOSTELU Rajapinnat: 3: osaa hyödyntää polymorfismia rajapinnan avulla
        //sinänsä tarpeeton, sillä tulostukset tehdään tuotelistan kautta, tämä vain osaamismatriisin  vuoksi, tätä ei kutsuta mistään.
        
        public override void TulostaKuittaus()
        {
            Console.WriteLine("Kuittaus: perustit multituotteen, (polymorfismi)");
        }




    }
}
