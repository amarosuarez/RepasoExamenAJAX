class clsPersona {

    /**
     * Constructor con parámetros
     */
    constructor(id, nombre, apellidos, edad) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.edad = edad;
    }
}


window.onload = function () {
    let id;
    let personaSeleccionada;

    /**
     * Función que obtiene todas las personas de la API
     */
    function obtenerPersonas() {
        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "http://localhost:5035/api/personas");

        // Definición de estados
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // Podriamos mostrar un gif, pero al ser en local no va a haber un gran tiempo de espera
            } else {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    arrayPersonas = JSON.parse(miLlamada.responseText);

                    // Obtengo el div donde va el contenido
                    let contenido = document.getElementById("contenido");

                    // Limpiamos lo que haya
                    contenido.innerHTML = "";

                    // Creo una tabla
                    let table = document.createElement("table");

                    // Creo un encabezado
                    let trEncabezado = document.createElement("tr");

                    // Creo las celdas del encabezado
                    let thId = document.createElement("th");
                    let thNombre = document.createElement("th");
                    let thApellidos = document.createElement("th");
                    let thEdad = document.createElement("th");
                    let thAcciones = document.createElement("th");

                    // Pongo los titulos a las celdas
                    thId.innerHTML = "ID";
                    thNombre.innerHTML = "Nombre";
                    thApellidos.innerHTML = "Apellidos";
                    thEdad.innerHTML = "Edad";
                    thAcciones.innerHTML = "Acciones"

                    // Añado las celdas al encabezado
                    trEncabezado.appendChild(thId);
                    trEncabezado.appendChild(thNombre);
                    trEncabezado.appendChild(thApellidos);
                    trEncabezado.appendChild(thEdad);

                    // Añado el encabezado a la tabla
                    table.appendChild(trEncabezado)

                    // Foreach de las personas
                    arrayPersonas.forEach(p => {
                        // Creamos la persona
                        let persona = new clsPersona(p.id, p.nombre, p.apellidos, p.edad);

                        // Creamos una fila
                        let tr = document.createElement("tr");

                        // Creamos las celdas
                        let tdId = document.createElement("td");
                        let tdNombre = document.createElement("td");
                        let tdApellidos = document.createElement("td");
                        let tdEdad = document.createElement("td");

                        // Escribimos los datos
                        tdId.innerHTML = persona.id;
                        tdNombre.innerHTML = persona.nombre;
                        tdApellidos.innerHTML = persona.apellidos;
                        tdEdad.innerHTML = persona.edad;

                        // Añadimos las celdas a la fila
                        tr.appendChild(tdId);
                        tr.appendChild(tdNombre);
                        tr.appendChild(tdApellidos);
                        tr.appendChild(tdEdad);

                        // Añadimos la fila a la tabla
                        table.appendChild(tr);

                        // Si pulsa en la fila, cogemos su id
                        tr.addEventListener("click", function () {
                            id = persona.id;
                        })
                    })

                    // Añado la tabla al contenido
                    contenido.appendChild(table)
                }
            }
        }

        miLlamada.send();
    }

    /**
     * Función que busca una persona
     * @param {any} idPersona ID de la persona a buscar
     */
    function buscarPersona(idPersona) {
        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "http://localhost:5035/api/personas/" + idPersona);

        // Definición de estados
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // Podriamos mostrar un gif, pero al ser en local no va a haber un gran tiempo de espera
            } else {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    let per = JSON.parse(miLlamada.responseText);

                    let persona = new clsPersona(per.id, per.nombre, per.apellidos, per.edad);

                    // Obtengo el div donde va el contenido
                    let contenido = document.getElementById("contenido");

                    // Limpiamos lo que haya
                    contenido.innerHTML = "";

                    contenido.innerHTML = `<div id="persona">ID --> ${persona.id}<br>Nombre --> ${persona.nombre}<br>Apellidos --> ${persona.apellidos}<br>Edad --> ${persona.edad}</div>`;

                    // Cuando pulse en el div, cogemos su id
                    document.getElementById("persona").addEventListener("click", function () {
                        console.log("lo pulsa" + persona.id);
                        id = persona.id;
                    })
                }
            }
        }

        miLlamada.send();
    }

    /**
     * Función que elimina una persona
     * @param {any} idPersona ID de la persona a eliminar
     */
    function eliminarPersona(idPersona) {
        let done = confirm("¿Estás seguro de que deseas eliminar a esta persona?")

        if (done) {
            var miLlamada = new XMLHttpRequest()

            miLlamada.open("DELETE", "http://localhost:5035/api/personas/" + idPersona)

            miLlamada.onreadystatechange = function () {
                if (miLlamada.readyState < 4) {
                    //aquí se puede poner una imagen de un reloj o un texto “Cargando”
                    // document.getElementById("cargando").innerHTML = "Cargando"
                } else {
                    if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                        alert("Persona eliminada correctamente")

                        // Llamamos de nuevo a la función para recargar los datos
                        obtenerPersonas()
                    }
                }
            }

            miLlamada.send()
        }
    }

    /**
     * Función que añade una persona
     * @param {any} persona Persona a añadir
     */
    function addPersona(persona) {
        var miLlamada = new XMLHttpRequest()

        miLlamada.open("POST", "http://localhost:5035/api/personas/")

        miLlamada.setRequestHeader('Content-type', 'application/json charset=utf-8')

        var json = JSON.stringify(persona)

        // Definicion estados
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                alert("Persona insertada con exito")
            }
        }

        miLlamada.send(json)
    }

    /**
     * Función que modifica una persona
     * @param {any} id ID de la persona a modificar
     */
    function modificarPersona(id) {
        var miLlamada = new XMLHttpRequest();

        miLlamada.open("GET", "http://localhost:5035/api/personas/" + id);

        // Definición de estados
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // Podriamos mostrar un gif, pero al ser en local no va a haber un gran tiempo de espera
            } else {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    let per = JSON.parse(miLlamada.responseText);

                    let persona = new clsPersona(per.id, per.nombre, per.apellidos, per.edad);


                    let nombre = document.getElementById("inputNombre");
                    let apellidos = document.getElementById("inputApellidos");
                    let edad = document.getElementById("inputEdad");
                    let btnEditar = document.getElementById("btnEditar");

                    nombre.innerHTML = persona.nombre;
                    nombre.value = persona.nombre;
                    apellidos.innerHTML = persona.apellidos;
                    apellidos.value = persona.apellidos;
                    edad.innerHTML = edad.value;
                    edad.value = persona.edad;
                    btnEditar.style.visibility = "visible";

                    btnEditar.addEventListener("click", function () {
                        console.log(persona.id);
                        var miLlamadaPut = new XMLHttpRequest()

                        miLlamadaPut.open("PUT", "http://localhost:5035/api/personas/" + persona.id)

                        miLlamadaPut.setRequestHeader('Content-type', 'application/json charset=utf-8')

                        let personaModificada = new clsPersona(persona.id, nombre.value, apellidos.value, edad.value)

                        var json = JSON.stringify(personaModificada)

                        // Definicion estados
                        miLlamadaPut.onreadystatechange = function () {
                            if (miLlamadaPut.readyState < 4) {
                                //aquí se puede poner una imagen de un reloj o un texto “Cargando”
                            } else if (miLlamadaPut.readyState == 4 && miLlamadaPut.status == 200) {
                                alert("Persona modificada con exito")
                                nombre.innerHTML = "";
                                nombre.value = "";
                                apellidos.innerHTML = "";
                                apellidos.value = "";
                                edad.innerHTML = "";
                                edad.value = 0;
                                obtenerPersonas()
                            }
                        }

                        miLlamadaPut.send(json)
                    })

                }
            }
        }

        miLlamada.send();
    }

    document.getElementById("btnListar").addEventListener("click", function () {
        obtenerPersonas();
    })

    document.getElementById("btnBuscar").addEventListener("click", function () {
        let id = document.getElementById("inputId").value;

        if (id == "") {
            alert("Rellena el input");
        } else {
            buscarPersona(id);
        }
    })

    document.getElementById("btnEliminar").addEventListener("click", function () {
        eliminarPersona(id);
    })

    document.getElementById("btnAdd").addEventListener("click", function () {
        let nombre = document.getElementById("inputNombre").value;
        let apellidos = document.getElementById("inputApellidos").value;
        let edad = document.getElementById("inputEdad").value;

        document.getElementById("btnAdd").style.visibility = "visible";
        document.getElementById("btnEditar").style.visibility = "hidden";

        if (nombre == "" || apellidos == "" || edad == "") {
            alert("Rellena los campos");
        } else {
            let persona = new clsPersona(0, nombre, apellidos, edad);
            addPersona(persona);
        }
    })

    document.getElementById("btnEditarPer").addEventListener("click", function () {
        console.log(id);
        if (id === "" || id === null || id === undefined || id < 0) {
            alert("Selecciona una persona");
        } else {
            document.getElementById("btnAdd").style.visibility = "hidden";
            modificarPersona(id);
        }
    })
}