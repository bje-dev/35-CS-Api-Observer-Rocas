﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente___Observer
{
    public class IgneasObserver : IObserver
    {
        private int totalIgneas = 0;


        public void Actualizar(ISubject roc)
        {
            if ((roc as Roca).Tipo == "igneas")
            {
                totalIgneas++;
                MessageBox.Show("Total igneas: " + totalIgneas);


            }
        }
    }
}
