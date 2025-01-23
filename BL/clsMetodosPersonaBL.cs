using DAL;
using ENT;

namespace BL
{
    public class clsMetodosPersonaBL
    {
        /// <summary>
        /// Función que obtiene todas las personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<clsPersona> obtenerPersonasBL()
        {
            return clsMetodosPersonaDAL.obtenerPersonasDAL();
        }

        /// <summary>
        /// Función que obtiene una persona por su id
        /// </summary>
        /// <param name="id">Id de la persona a buscar</param>
        /// <returns>Persona</returns>
        public static clsPersona obtenerPersonaPorIdBL(int id)
        {
            return clsMetodosPersonaDAL.obtenerPersonaPorIdDAL(id);
        }

        /// <summary>
        /// Función que añade una persona
        /// </summary>
        /// <param name="persona">Persona a insertar</param>
        /// <returns>True si la ha añadido, False si no</returns>
        public static bool insertarPersonaBL(clsPersona persona)
        {
            return clsMetodosPersonaDAL.insertarPersonaDAL(persona);
        }

        /// <summary>
        /// Función que edita una persona
        /// </summary>
        /// <param name="personaModificada">Persona modificada</param>
        /// <returns>True si ha editado a la persona, False si no</returns>
        public static bool editarPersonaBL(clsPersona personaModificada)
        {
            return clsMetodosPersonaDAL.editarPersonaDAL(personaModificada);
        }

        /// <summary>
        /// Función que elimina una persona
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>True si la ha eliminado, false si no</returns>
        public static bool eliminarPersonaBL(int id)
        {
            return clsMetodosPersonaDAL.eliminarPersonaDAL(id);
        }
    }
}
