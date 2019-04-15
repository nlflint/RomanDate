using System.Collections.Generic;
using System;

namespace ClassLibrary1 {
    public class DenominationSet {
            public DenominationSet(IList<string> denominations)
            {
                
                Small = denominations[0];
                Medium = denominations[1];
                Large = denominations[2];

                Console.WriteLine("set large: " + Large);
            }

            public string Small {get;}
            public string Medium {get;}
            public string Large {get;}
        }
}