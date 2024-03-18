using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente___Observer
{
    public class MetaforicasObserver : IObserver
    {
        private int totalMetaforicas = 0;


        public void Actualizar(ISubject roc)
        {
            if ((roc as Roca).Tipo == "metaforicas")
            {
                totalMetaforicas++;
                MessageBox.Show("Total metaforicas: " + totalMetaforicas);


            }
        }
    }
}
