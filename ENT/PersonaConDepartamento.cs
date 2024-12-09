using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class PersonaConDepartamento : Persona
    {
        private string _nombreDepartamento = "";
        public string NombreDepartamento { get { return _nombreDepartamento; } set { _nombreDepartamento = value; } }

        public PersonaConDepartamento() { }

        public PersonaConDepartamento(string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento, List<Departamento> departamentos)
            : base(nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento)
        {
            Departamento? dept = departamentos.Find(d => d.ID == idDepartamento);

            if (dept != null)
                _nombreDepartamento = dept.Nombre;
        }

        public PersonaConDepartamento(Persona p, List<Departamento> departamentos) : base(p)
        {
            Departamento? dept = departamentos.Find(d => d.ID == p.IDDepartamento);

            if (dept != null)
                _nombreDepartamento = dept.Nombre;
        }
    }
}
