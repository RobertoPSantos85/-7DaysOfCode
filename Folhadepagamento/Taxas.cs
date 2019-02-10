using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Folhadepagamento
{
    public static class Taxas
    {
       public static double CalculaINSS(double salBruto)
        {
            if (salBruto <= 965.67) return salBruto * 0.08;
            else if (salBruto <= 1609.45) return salBruto * 0.09;
            else if (salBruto <= 3218.90) return salBruto * 0.11;
            else return (354.08);

        }

        public static double CalculaIR(double salIR)
        {
            if (salIR <= 1434.59) return (0);
            else if (salIR <= 2150.00) return salIR * 0.075 - 107.59;
            else if (salIR <= 2866.70) return salIR * 0.15 - 268.84;
            else if (salIR <= 3582.00) return salIR * 0.225 - 483.84;
            else return salIR * 0.275 - 662.94;
        }
    }
}
