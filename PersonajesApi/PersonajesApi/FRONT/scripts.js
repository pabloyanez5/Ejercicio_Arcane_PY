// URL de la API
const apiUrl = "http://localhost:5275/swagger/index.html";


function getPersonajes() {
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            const personajesList = document.getElementById("personajesList");
            personajesList.innerHTML = ''; 
            data.forEach(personaje => {
                const li = document.createElement("li");
                li.textContent = `ID: ${personaje.id}, Nombre: ${personaje.nombre}, Edad: ${personaje.edad}, Rol: ${personaje.rol}`;
                personajesList.appendChild(li);
            });
        })
        .catch(error => console.error("Error:", error));
}


function addPersonaje(event) {
    event.preventDefault();

    const nombre = document.getElementById("nombre").value;
    const edad = document.getElementById("edad").value;
    const rol = document.getElementById("rol").value;

    const nuevoPersonaje = {
        nombre: nombre,
        edad: parseInt(edad),
        rol: rol
    };

    fetch(apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(nuevoPersonaje)
    })
        .then(response => response.json())
        .then(() => {
            alert("Personaje agregado con éxito!");
            getPersonajes(); 
        })
        .catch(error => console.error("Error:", error));
}


document.addEventListener("DOMContentLoaded", function () {
    getPersonajes();


    const form = document.getElementById("addPersonajeForm");
    form.addEventListener("submit", addPersonaje);
});
