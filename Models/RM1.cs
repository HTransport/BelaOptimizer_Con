using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelaOptimizer_Con.Models
{
    class RM1
    {
        public string RS { get; set; }
        public bool Ended { get; set; }

        public RM1(string rs, bool e)
        {
            RS = rs;
            Ended = e;
        }
    }
}
