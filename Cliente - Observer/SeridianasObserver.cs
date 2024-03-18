using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente___Observer
{
    public class SeridianasObserver : IObserver
    {
        private int totalSeridianas = 0;


        public void Actualizar(ISubject roc)
        {
            if ((roc as Roca).Tipo == "seridianas")
            {
                totalSeridianas++;
                MessageBox.Show("Total seridianas: " + totalSeridianas);


            }
        }
    }
}
