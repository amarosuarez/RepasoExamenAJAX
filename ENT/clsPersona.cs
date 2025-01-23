namespace ENT
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private int edad;
        #endregion

        #region Propiedades
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value >= 0)
                {
                    this.id = value;
                }
            }
        }

        public String Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.nombre = value;
                }
            }
        }

        public String Apellidos
        {
            get
            {
                return this.apellidos;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.apellidos = value;
                }
            }
        }

        public int Edad
        {
            get
            {
                return this.edad;
            }

            set
            {
                if (value >= 0)
                {
                    this.edad = value;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public clsPersona() {}

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        public clsPersona(String nombre, String apellidos, int edad)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre;
            }

            if (!string.IsNullOrEmpty(apellidos))
            {
                this.apellidos = apellidos;
            }

            if (edad >= 0)
            {
                this.edad = edad;
            }
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        public clsPersona(int id, String nombre, String apellidos, int edad)
        {
            if (id >= 0)
            {
                this.id = id;
            } 

            if (!string.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre;
            }

            if (!string.IsNullOrEmpty(apellidos))
            {
                this.apellidos = apellidos;
            }

            if (edad >= 0)
            {
                this.edad = edad;
            }
        }
        #endregion
    }
}
