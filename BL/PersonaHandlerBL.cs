using DAL;
using ENT;

namespace BL
{
    public class PersonaHandlerBL
    {
        public static List<Persona> getPersonas()
        {
            return PersonaHandlerDAL.getPersonas();
        }

        public static Persona getPersona(int id)
        {
            return PersonaHandlerDAL.getPersona(id);
        }

        public static PersonaConDepartamento getPersonaConDepartamento(int id)
        {
            return PersonaHandlerDAL.getPersonaConDepartamento(id);
        }

        public static int addPersona(Persona p)
        {
            return PersonaHandlerDAL.addPersona(p);
        }

        public static int updatePersona(Persona p)
        {
            return PersonaHandlerDAL.updatePersona(p);
        }

        public static int deletePersona(int id)
        {
            return PersonaHandlerDAL.deletePersona(id);
        }
    }
}
