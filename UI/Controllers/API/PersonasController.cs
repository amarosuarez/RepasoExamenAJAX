using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        /// <summary>
        /// Función que obtiene el listado de personas y los devuelve a la api
        /// </summary>
        /// <returns>Listado de personas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> personas = new List<clsPersona>();

            try
            {
                personas = clsMetodosPersonaBL.obtenerPersonasBL();

                if (personas.Count > 0)
                {
                    salida = Ok(personas);
                } else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        /// <summary>
        /// Función que obtiene una persona y la devuelve a la API
        /// </summary>
        /// <param name="id">Id de la persona a obtener</param>
        /// <returns>Persona</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona = new clsPersona();

            try
            {
                persona = clsMetodosPersonaBL.obtenerPersonaPorIdBL(id);

                if (persona != null)
                {
                    salida = Ok(persona);
                } else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        /// <summary>
        /// Función que añade una persona a la API
        /// </summary>
        /// <param name="persona">Persona a añadir</param>
        /// <returns>Devuelve si ha añadido a la persona o no</returns>
        [HttpPost]
        public IActionResult Post(clsPersona persona)
        {
            IActionResult salida;
            bool added;

            try
            {
                added = clsMetodosPersonaBL.insertarPersonaBL(persona);
                
                if (added)
                {
                    salida = Ok(added);
                } else
                {
                    salida = NotFound();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        /// <summary>
        /// Función que modifica una persona
        /// </summary>
        /// <param name="id">Id de la persona a modificar</param>
        /// <param name="personaModificada">Persona modificada</param>
        /// <returns>True si la ha modificado, False si no</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, clsPersona personaModificada)
        {
            bool modified;
            IActionResult salida;

            try
            {
                // Le pongo el id a la persona ya que la función de la BL obtiene el id del objeto
                personaModificada.Id = id;
                modified = clsMetodosPersonaBL.editarPersonaBL(personaModificada);
                
                if (modified)
                {
                    salida = Ok(modified);
                }
                else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        /// <summary>
        /// Función que elimina una persona
        /// </summary>
        /// <param name="id">Id de la persona a eliminar</param>
        /// <returns>True si ha eliminado, False si no</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted;
            IActionResult salida;

            try
            {
                deleted = clsMetodosPersonaBL.eliminarPersonaBL(id);

                if (deleted)
                {
                    salida = Ok(deleted);
                } else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }
    }
}
