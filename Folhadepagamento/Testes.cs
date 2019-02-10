using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Folhadepagamento
{
   public class Testes
    {
        public static char consistNum(char c)
        {
             if(((c < '0') || (c > '9')) && c != ',' && c != (char)8)
            {
                MessageBox.Show("Tecla inválida.");
                c = (char)0;
            }
            return (c);
        }

        public static char soumaVirgula(string texto)
        {
            int i;
            i = texto.IndexOf(',');
            if (i >= 0)
            {
                MessageBox.Show("Vírgula já existente.");
                return ((char)0);
            }
            else
                return (',');
        }

        public static char consistLet(char c)
        {
            if (!((c < '0') || (c > '9')))
              {
                MessageBox.Show("Digite apenas letras.");
                c = (char)0;
            }
            return c;
        }
    }
}
