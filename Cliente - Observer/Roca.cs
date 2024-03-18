using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente___Observer
{
    public class Roca : ISubject
    {
       
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Origen { get; set; }
        public string Tamaño { get; set; }
        public string Lugar { get; set; }

        private List<IObserver> observadores = new List<IObserver>();

        public void NotificarResultado()
        {
            foreach (var observador in observadores)
            {
                observador.Actualizar(this);
            }
        }

        public void QuitarObservador(IObserver observador)
        {
            this.observadores.Remove(observador);
            MessageBox.Show("Subject: Detached an observer.");
        }

        public void RegistrarObservador(IObserver observador)
        {
            MessageBox.Show("Subject: Attached an observer.");
            this.observadores.Add(observador);
        }


        public void SomeBusinessLogic()
        {
            this.NotificarResultado();
        }
    }
}
