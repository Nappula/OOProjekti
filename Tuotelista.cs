using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace UusiProjektityö
{

    [Serializable]
    class Tuotelista : Rajapinnat.ITulostaViestiUlkoa

    {

        //ARVOSTELU oliot 2: osaa luoda dynaamisen oliokokoelman.
        private Tuote[,] tuotteet = new Tuote[15, 5];


        #region lisaaTuote -määrittelyt
        /// <summary>
        /// Tarkistaa onko tuote jo olemassa, etsii tuotteelle seuraavan vapaan hyllypaikan ja lisää tuotteet listaan.
        /// </summary>
        /// <param name="tuotenumero">tuotetta etsitään tuotteen string tyyppisen tuotenumeron perusteella</param>
        public void LisaaTuote(string tuotenumero)
        {
            //ARVOSTELU oliot 1: Osaa luoda luokasta olion.
            Tuote tuote = new Tuote(tuotenumero);

            //TODO tarkasta että annettavaa tuotetta ei vielä löydy järjestelmästä.
            //LoytyykoTuote(tuotenumero); //TODO KORJAA!!!!  palauttaa löytyyko tuote boolean tyyppisenä.

            //etsitään seuraava vapaa hyllypaikka.
            int[] koordinaatit = EtsiSeuraavaVapaaPaikka();
            //lisätään tuote taulukkoon annettujen parametrien mukaan.

            int rivi = koordinaatit[0];
            int sarake = koordinaatit[1];

            tuotteet[rivi, sarake] = tuote;
            tuote.sijaintiX = rivi;
            tuote.sijaintiY = sarake;

            tuote.TulostaKuittaus();


            Console.WriteLine("Tuote {0} lisätty hyllypaikkaan {1}-{2}", tuote.tuotenumero, rivi, sarake);
        }

        /// <summary>
        /// Tarkistaa onko tuote jo olemassa, etsii tuotteelle seuraavan vapaan hyllypaikan ja lisää tuotteet listaan.
        /// </summary>
        /// <param name="tuotenumero">tuotetta etsitään tuotteen string tyyppisen tuotenumeron perusteella</param>
        /// <param name="tuotenimi">tuotteelle on mahdollista antaa myöstuotenimi string tyyppisenä</param>
        public void LisaaTuote(string tuotenumero, string tuotenimi)
        {

            Tuote tuote = new Tuote(tuotenumero, tuotenimi);

            //tarkasta että annettavaa tuotetta ei vielä löydy järjestelmästä.
            //LoytyykoTuote(tuotenumero); //TODO KORJAA!!!!  palauttaa löytyyko tuote boolean tyyppisenä.

            //etsitään seuraava vapaa hyllypaikka.
            int[] koordinaatit = EtsiSeuraavaVapaaPaikka();
            //lisätään tuote taulukkoon annettujen parametrien mukaan.

            int rivi = koordinaatit[0];
            int sarake = koordinaatit[1];

            tuotteet[rivi, sarake] = tuote;
            tuote.sijaintiX = rivi;
            tuote.sijaintiY = sarake;
            tuote.tuotenimi = tuotenimi;
            tuote.TulostaKuittaus();


            Console.WriteLine("Tuote {0} lisätty hyllypaikkaan {1}-{2}", tuote.tuotenumero, rivi, sarake);
        }


        //ARVOSTELU Luokkarakenne 5: osaa määritellä luokan, jossa hyödynnetään metodin ylikirjoittamista
        //virtual sinänsä tarpeeton, varsinaista ylikirjoitusta ei tarvitse tehdä perityn luokan ja periytyvän luokan välillä, sillä parametrien määrä kertoo mitä metodia käytetään (overload).
        public virtual void LisaaTuote(string tuotenumero, string tuotenimi, string multituoteNumero)
        {
            Multituote tuote = new Multituote(tuotenumero, tuotenimi, multituoteNumero);


            //tällä osoitetaan ainoastaan luokan periytyminen, ei käyttössä tässä ohjelmaversiossa
            //tarkoituksena oli niputtaa kaikki saman multituotteen omaavat tuotteet samaan laitteen lokeroon.
            //2d lista ei mahdollista tätä ilman listaa listan sisällä ja tämän saavuttamiseksi pitäisi aiempaa koodia muuttaa niin paljon,
            //että olisi järkevämpää toteuttaa koko järjestelmä listan päälle, tai muodostaa jokaisesta tuotteesta oma lista ja sijoittaa se 2d taulukkoon.
            //tämä taasen toisi aiheuttaisi halujen uudelleen kirjoittamisen, joten tätä ominaisuutta ei oteta käyttöön tähän versioon.

            int[] koordinaatit = EtsiSeuraavaVapaaPaikka();
            int rivi = koordinaatit[0];
            int sarake = koordinaatit[1];

            tuotteet[rivi, sarake] = tuote;
            tuote.sijaintiX = rivi;
            tuote.sijaintiY = sarake;

            tuote.tuotenumero = tuotenumero;
            tuote.tuotenimi = tuotenimi;
            tuote.multituotenumero = multituoteNumero;

            tuote.TulostaKuittaus();

            Console.WriteLine("Tuote {0} lisätty hyllypaikkaan {1}-{2}, tuotteen multituotenumero on {3}", tuote.tuotenumero, rivi, sarake, multituoteNumero);

        }


        public void  LisaaTuote(string tuotenumero, string tuotenimi, int sijaintiX, int sijaintiY)
        {

            Tuote tuote = new Tuote(tuotenumero, tuotenimi);
      
            //lisätään tuote taulukkoon annettujen parametrien mukaan.

            int rivi = sijaintiX;
            int sarake = sijaintiY;

            tuotteet[rivi, sarake] = tuote;
            tuote.sijaintiX = rivi;
            tuote.sijaintiY = sarake;
            tuote.tuotenimi = tuotenimi;
            tuote.TulostaKuittaus();


            Console.WriteLine("Tuote {0} lisätty hyllypaikkaan {1}-{2}", tuote.tuotenumero, rivi, sarake);
        }
        #endregion

        public void TulostaViestiUlkoa() { 
        

       
        }






        public void TyhjennaTaulukko()
        {

            int rivi = tuotteet.GetLength(0);
            int sarake = tuotteet.GetLength(1);


            for (int i = 0; i < rivi; i++)
            {
                for (int j = 0; j < sarake; j++)
                {
                    Array.Clear(tuotteet, i, j);
                   
                }
                
            }
        }


        /// <summary>
        /// Etsii taulukosta seuraavan vapaan hyllypaikan numeron ja palauttaa sen int[2] arrayssa. 
        /// </summary>
        /// <returns>int[2]</returns>
        public int[] EtsiSeuraavaVapaaPaikka()
        {
            int rivi = tuotteet.GetLength(0);
            int sarake = tuotteet.GetLength(1);

            for (int i = 0; i < rivi; i++)
            {
                for (int j = 0; j < sarake; j++)
                {

                    if (tuotteet[i, j] == null)
                    {
                        int[] koordinaatit = new int[2];
                        koordinaatit[0] = i;
                        koordinaatit[1] = j;
                        // Console.WriteLine("{0}-[1}", koordinaatit[0], koordinaatit[1]); // testausta
                        return koordinaatit;

                    }

                }
            }
            Console.WriteLine("Automaatti on täynnä. Ei voi lisätä uusia tuotteita.");
            //TODO Mitä tehdään kun automaatti on täynnä. (alla oleva return null; riittäisikö tämä siihen että tuotetta lisätessä tuote lisätään paikkaan null.... ei toimi muissa metodeissa tätä metodia kätyettäessä...
            return null;
        }



        /// <summary>
        /// Tulostaa tuotteen tiedot, tuotenumero, [tuotenimi]
        /// </summary>
        /// <param name="tuote"></param>

        public void Tulosta(string tuote)
        {
            //käydään tuotteet array läpi rivi riviltä. foreach käy koska ei tarvita tuotteen sijaintia taulukossa.
            foreach (var t in tuotteet)
            {
                //jos tuote ei ole "null", tällä estetään null.tuotenumero, joka aiheuttaa käännöksen aikaisen virheen.
                if (t != null)
                {
                    //jos tuotenumeero on parametrina annettu, eli tuote löytyy.
                    if (t.tuotenumero == tuote)
                    {
                        //tulostetaan tuotteen tiedot.
                        Console.WriteLine("Tuotteen tietojen tulostus:");
                        Console.WriteLine("Tuotenumero: {0}", t.tuotenumero);
                        if (t.tuotenimi != null)
                        {
                            Console.WriteLine("Tuotteen nimi on: {0} ", t.tuotenimi);
                        }

                        Console.WriteLine("Hyllypaikassa: {0}-{1} ", t.sijaintiX, t.sijaintiY);

                    }
                }
            }
        }

        public void TulostaNumeroJarjestyksessa()
        {
            List<Tuote> tuotteetListassa = new List<Tuote>();
            foreach (var t in tuotteet)
            {
                tuotteetListassa.Add(t);
            }
            tuotteetListassa.Sort();
        }


        /// <summary>
        /// Tulostaa varastopaikat helposti hahmotettavassa matriisissa
        /// </summary>
        public void TulostaVarastopaikat()
        {
            //https://stackoverflow.com/questions/12826760/printing-2d-array-in-matrix-format
            int rivi = tuotteet.GetLength(0);
            int sarake = tuotteet.GetLength(1);


            for (int i = 0; i < rivi; i++)
            {
                for (int j = 0; j < sarake; j++)
                {
                    if (tuotteet[i, j] == null)
                    {
                        Console.Write(string.Format("|\t tyhjä \t|"));
                    }
                    else
                    {
                        Console.Write(string.Format("|\t {0} \t|", tuotteet[i, j].tuotenumero));
                    }
                }
                Console.Write(Environment.NewLine); //Enviroment.NewLine sanotaan yllä esimerkkilinkin aineistossa toimivan kaikissa ympäristöissä (eikö WriteLine(); sitten toimio?) 
            }

        }



        /// <summary>
        /// tarkastaa löytyykö haettavaa tuotetta jo järjestelmästä.
        /// return: bool.
        /// </summary>
        /// <param name="haettavaTuote"></param>
        /// <returns></returns>

        public bool LoytyykoTuote(string haettavaTuote)
        {
            //käy taulukko läpi rivi-riviltä

            bool loytyikoTuote;


            int rivi = tuotteet.GetLength(0);
            int sarake = tuotteet.GetLength(1);

            for (int i = 0; i < rivi; i++)
            {
                for (int j = 0; j < sarake; j++)
                {
                    //Console.Write("x");
                    if (tuotteet[i, j].Equals(haettavaTuote))
                    {
                        Console.Write(string.Format("tuote löytyi"));
                        loytyikoTuote = true;
                        return loytyikoTuote;
                    }
                    //else
                    //{
                    //    Console.Write(string.Format("tuotetta ei löytynyt"));
                    //    loytyikoTuote = false;
                    //    return loytyikoTuote;
                    //}
                }
                Console.Write(Environment.NewLine);
            }
            return false;

        }


        /// <summary>
        /// Tarkistaa onko hyllypaikka vapaana.
        /// Palauttaa vastauksen boolean tyyppisenä
        /// </summary>
        /// <param name="a">Varastolistataulukon solon X suuntainen arvo</param>
        /// <param name="b">Varastolistataulukon solon Y suuntainen arvo</param>
        /// <returns>boolean (true/false)</returns>
        public bool OnkoHyllypaikkaVapaa(int rivi, int sarake)
        {

            if (tuotteet[rivi, sarake] == null)
            {
                Console.WriteLine("hyllypaikka on vapaa");
                return true;
            }
            else
            {
                Console.WriteLine("hyllypaikka on varattu");
                return false;
            }




            // vaihtoehto
            //return (tuotteet[a, b] == null);

            //if (tuotteet[a, b] == null)
            //{
            //    Console.WriteLine("hyllypaikka {0}-{1} on vapaa", a, b);
            //}
            //else
            //{
            //    Console.WriteLine("hyllypaikka {0}-{1} on varattu", a, b);
            //}
        }




        public void TallennaTiedostoon()
        //ARVOSTELU tallentaminen 3: osaa tallentaa oliodatan tiedostoon
        //https://www.dotnetperls.com/serialize-list
        {
            //viimeistään tässä kohtaa 2d taulukon käyttö on kuin ampuisi itseään jalkaan...
            //purkkapatenttina luetaan taulukko solu-solulta listaan ( tuotteilla on kuitenkin koordinaatit, missä ne sijaitsevat 2d taulukossa.)

            List<Tuote> tuotteetListassa = new List<Tuote>();

            foreach (var tuote in tuotteet)
            {
                tuotteetListassa.Add(tuote);
            }

            Console.WriteLine("Tuotteet luettu taulukosta listaan, sarjallistettu ja kirjoitettu tiedostoon tallennus.bin");

            //foreach (var tuote in tuotteetListassa)
            //{
            //    Console.WriteLine(tuote);
            //}

            try
            {
                using (Stream stream = File.Open("tallennus.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, tuotteetListassa);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("virhe sarjallistamisessa tai tiedostoon tallentamisessa.");
            }
        }



        public void LueTiedostosta()
        //https://www.dotnetperls.com/serialize-list
        {
            //ARVOSTELU tallentaminen 4: osaa ladata oliodatan tiedostosta
            //ARVOSTELU Tallentaminen 5 osaa hyödyntää oliodatan sarjallistamista
            //ARVOSTELU oliot 2 osaa luoda dynaamisen oliokokoelman.
            List<Tuote> tuotteetListassa = new List<Tuote>();

            try
            {
                using (Stream stream = File.Open("tallennus.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var tuotteetListaan = (List<Tuote>)bin.Deserialize(stream);

                    //TODO korjaa, Multituotetta ja Tuotetta ei pysty yhdistämään suoraan, multituotteen tiedot tuhoutuu luvun yhteydessä, multituotenumero tosin tehtävässä vain perimisen takia. 
                    foreach (Tuote tuote in tuotteetListaan)
                    {

                        if (tuote != null)
                        {
                           LisaaTuote(tuote.tuotenumero, tuote.tuotenimi,tuote.sijaintiX,tuote.sijaintiY);
                        }

                        //if (tuote != null)
                        //{
                        //    Console.WriteLine("Tuotenumero: " + tuote.tuotenumero);
                        //    Console.WriteLine("Nimi: " + tuote.tuotenimi);
                        //    Console.WriteLine("Sijainti: {0}-{1}", tuote.sijaintiX, tuote.sijaintiY);
                        //    //if (tuote.multituotenumero != null)
                        //    //{
                        //    //    Console.WriteLine(tuote.multituotenumero);
                        //    //}
                        //}
                        
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("virhe tiedoston lukemisessa");
            }

        }
    }
}

