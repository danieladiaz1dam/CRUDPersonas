using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Departamento
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = "";

        public Departamento() { }

        public Departamento(int ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
