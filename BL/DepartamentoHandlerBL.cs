using DAL;
using ENT;

namespace BL
{
    public class DepartamentoHandlerBL
    {
        public static List<Departamento> getDepartamentos()
        {
            return DepartamentoHandlerDAL.getDepartamentos();
        }

        public static Departamento GetDepartamento(int id)
        {
            return DepartamentoHandlerDAL.getDepartamento(id);
        }
    }
}
