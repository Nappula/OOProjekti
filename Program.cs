using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UusiProjektityö
{






    class Program
    {
        static void Main(string[] args)
        {
            










            Tuotelista tuotelista = new Tuotelista();


            Console.WriteLine("lisätään tuote taulukkoon.");
            tuotelista.LisaaTuote("1");
            Console.WriteLine();

            Console.WriteLine("tulostetaan tietoja lisätystä tuotteesta");
            tuotelista.Tulosta("1");
            Console.WriteLine();

            tuotelista.LisaaTuote("20", "tuoteNimeltäänTuote2");
            tuotelista.Tulosta("20");
            Console.WriteLine();

            Console.WriteLine("arkastetaan onko 3-3 hyllypaikka vapaa");
            tuotelista.OnkoHyllypaikkaVapaa(3, 3);
            Console.WriteLine();

            Console.WriteLine("lisätään multituote");
            tuotelista.LisaaTuote("11", "tuote12", "1");
            Console.WriteLine();

            Console.WriteLine("tulostetaan varastopaikkojen sisältö");
            tuotelista.TulostaVarastopaikat();
            Console.WriteLine();

            Console.WriteLine("tallennetaan tuotteet tiedostoon");
            tuotelista.TallennaTiedostoon();
            Console.WriteLine();

            Console.WriteLine("tyhjennetään taulukko");
            tuotelista.TyhjennaTaulukko();
            tuotelista.TulostaVarastopaikat();


            Console.WriteLine("Luetaan tiedot tiedostosta.");
            tuotelista.LueTiedostosta();
            Console.WriteLine();



            //Console.WriteLine("Tulostetaan taulukossa olevat tuotteet tuotenumerojärjestyksessä");
            //tuotelista.TulostaNumeroJarjestyksessa();


            UusiProjektityö.Rajapinnat.ITulostaViestiUlkoa tuoteUlkoa = UusiProjektityö.UlkoinenLuokka.UlkoinenLuokka.LuoOlio();
            tuoteUlkoa.TulostaViestiUlkoa();


        }
    }

}
