using BL;
using ENT;

namespace ASP.Models.ViewModel
{

    public class PersonaConListaDepartamentosVM : Persona
    {
        public List<Departamento> departamentos = DepartamentoHandlerBL.getDepartamentos();

        public PersonaConListaDepartamentosVM() { }

        public PersonaConListaDepartamentosVM(Persona p)
        {
            Id = p.Id;
            Nombre = p.Nombre;
            Apellidos = p.Apellidos;
            Telefono = p.Telefono;
            Direccion = p.Direccion;
            Foto = p.Foto;
            FechaNacimiento = p.FechaNacimiento;
            IDDepartamento = p.IDDepartamento;
        }
    }
}
