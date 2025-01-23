using ENT;

namespace DAL
{
    public class clsMetodosPersonaDAL
    {
        /// <summary>
        /// Lista estática de personas
        /// </summary>
        public static List<clsPersona> personas = new List<clsPersona>
        {
            new clsPersona(0, "Amaro", "Suárez", 20),
            new clsPersona(1, "Rubén", "Ruiz", 19),
            new clsPersona(2, "Marta", "Díaz", 19),
            new clsPersona(3, "Jose Enrique", "Muñoz", 19),
            new clsPersona(4, "Elena", "Rivero", 34),
            new clsPersona(5, "Fernando", "Galiana", 52),
            new clsPersona(6, "Raúl", "Romera", 20),
            new clsPersona(7, "Sergio", "Guillem", 28),
            new clsPersona(8, "Antonio", "Olivares", 38),
            new clsPersona(9, "David", "Bermúdez", 35),
        };

        /// <summary>
        /// Función que obtiene todas las personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<clsPersona> obtenerPersonasDAL()
        {
            return personas;
        }

        /// <summary>
        /// Función que obtiene una persona por su id
        /// </summary>
        /// <param name="id">Id de la persona a buscar</param>
        /// <returns>Persona</returns>
        public static clsPersona obtenerPersonaPorIdDAL(int id)
        {
            return personas.Find(p => p.Id == id);
        }

        /// <summary>
        /// Función que añade una persona
        /// </summary>
        /// <param name="persona">Persona a insertar</param>
        /// <returns>True si la ha añadido, False si no</returns>
        public static bool insertarPersonaDAL(clsPersona persona)
        {
            bool added = false;
            int id = 0;

            // Busco el último índice
            int last = personas.Count - 1;

            // Si hay al menos una persona, le sumo 1
            if (last > -1)
            {
                // Obtengo el id de la última persona y le sumo 1
                id = personas[last].Id + 1;
            }

            // Le añado el id a la persona
            persona.Id = id;

            if (persona != null)
            {
                personas.Add(persona);
                added = true;
            }

            return added;
        }

        /// <summary>
        /// Función que edita una persona
        /// </summary>
        /// <param name="personaModificada">Persona modificada</param>
        /// <returns>True si ha editado a la persona, False si no</returns>
        public static bool editarPersonaDAL(clsPersona personaModificada)
        {
            bool modified = false;

            if (personaModificada != null)
            {
                int index = personas.FindIndex(p => p.Id == personaModificada.Id);

                personas[index] = personaModificada;

                modified = true;
            }

            return modified;
        }

        /// <summary>
        /// Función que elimina una persona
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>True si la ha eliminado, false si no</returns>
        public static bool eliminarPersonaDAL(int id)
        {
            bool deleted = false;
            int index = personas.FindIndex(p => p.Id == id);

            if (index >= 0)
            {
                personas.RemoveAt(index);
                deleted = true;
            }

            return deleted;
        }
    }
}
