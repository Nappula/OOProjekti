using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UusiProjektityö
{

    //ARVOSTELU oliot/3. osaa määritellä oliolle kentät ja metodit.
    //ARVOSTELU oliot/4. osaa määritellä näkyvyydet julkisiksi ja yksityisiksi.
    //ARVOSTELU oliot/5. Osaa määritellä oliolle property -kenttiä.

    [Serializable]
    class Tuote : IComparable<Tuote>, Rajapinnat.ITuote
    {
        private string _tuotenumero;
        private string _tuotenimi;
        private int _sijaintiX;
        private int _sijaintiY;

        //properties: get, set
        public string tuotenumero
        {

            get { return _tuotenumero; }
            set { _tuotenumero = value; }
        }

        public string tuotenimi
        {
            get { return _tuotenimi; }
            set { _tuotenimi = value; }
        }



        public int sijaintiX
        {
            get { return _sijaintiX; }
            set { _sijaintiX = value; }
        }
        public int sijaintiY
        {
            get { return _sijaintiY; }
            set { _sijaintiY = value; }
        }


        //Petteri Mäkelän käsialaa.. auttoi ylikirjoituksen tekemisessä
        public override bool Equals(object o)
        {
            string haettava = (string)o;
            return haettava.Equals(this.tuotenumero);
        }


        //constructors

        public Tuote(string _tuotenumero)
        {
            this.tuotenumero = _tuotenumero;
        }
        public Tuote(string _tuotenumero, string _tuotenimi)
        {
            this.tuotenumero = _tuotenumero;
            this.tuotenimi = _tuotenimi;
        }

        //methods

        //ARVOSTELU Rajapinnat: 3: osaa hyödyntää polymorfismia rajapinnan avulla
        public virtual void TulostaKuittaus()
        {
            Console.WriteLine("Tuote perustettu...");
        }

        // Määritellään IComparable luokan järjestämissäännöt
        public int CompareTo(Tuote other)
        {


            // TODO käytä tehtävässä tätä tuotteiden tulostamiseen numerojärjestyksessä, (IComparable täyttää rajapinnan ehdon osaamismatriisissa.)
            //Järjestä tuotteet tuotenumeron perusteella, palauttaa kokonaisluvun tuloksena, jos 0 = yhtäsuuret, käytetään toista määrettä (tässä ei mahdollista koska tuotenumero on uniikka) jos <0 this on pienempi ja >0 this on suurempi
            int tuotenumeroVertailu = this.tuotenumero.CompareTo(other.tuotenumero);
            //if (tuotenumeroVertailu == 0)
            //    tuotenumeroVertailu = this.tuotenumero.CompareTo(other.tuotenumero); //jos ei yhtä suuret niin vertaa uudelleen samaa???? KORJAA
            return tuotenumeroVertailu;


        }
    }
}



     