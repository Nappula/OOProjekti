using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UusiProjektityö.Rajapinnat
{
    public interface ITuote
    {
        //ARVOSTELU Rajapinnat 5: lähdekoodista on erotettu useampi osa rajapintojen avulla
        //määritellään että jokaisen rajapinnan toteuttavan luokan pitää sisältää vähintään tuotenumero
        string tuotenumero { get; set; }


        
        
    }
}