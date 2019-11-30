using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UusiProjektityö.UlkoinenLuokka
{
   class UlkoinenLuokka : UusiProjektityö.Rajapinnat.ITulostaViestiUlkoa
    {

        //Esimerkki otettu tunnilla käydystä aineistosta "rajapinta esimerkki"

        private UlkoinenLuokka()
        {

        }
        
        public void TulostaViestiUlkoa()
        {
            Console.WriteLine("Eri nimiavaruuksien avulla simuloitua rajapintojen käyttöä.");


        }

        public static UusiProjektityö.Rajapinnat.ITulostaViestiUlkoa LuoOlio()
        {
            return new UlkoinenLuokka();
        }


    }
}
