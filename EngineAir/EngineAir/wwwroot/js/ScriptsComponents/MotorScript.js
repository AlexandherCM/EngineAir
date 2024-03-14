
// Recorrer el objeto donde se contiene la información
Object.keys(Prototypes).forEach(key => {
    const Prototype = Prototypes[key];

    CreateFormsListener(Prototype);
});

//Obtener el contenido de los inputs de un formulario
function GetFormsData(event){
    let Objetos = {};
    let formData = new FormData(event.target);

    formData.forEach((value, key) => {
        Objetos[key] = value;
    });
    return Objetos;
} 

// Evento observador - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
function CreateFormsListener(Prototype) {
    document.getElementById(Prototype.Brand).addEventListener('submit', (event) => {
        // Detener evento de recarga
        event.preventDefault();
        let Objects = GetFormsData(event);

        // Objeto ViewModel
        let MarcaTipo = {
            Nombre: Objects.Nombre,
            Estado : true,
            Entidad: Objects.Entidad
        };

        //Petición con la api
        api.SendPost(`api/ComponenteTipo/Create`, MarcaTipo)
            .then(data => {
                console.log("Solicitud recibida por el servidor correctamente.");
            })
            .catch(error => {
                console.error('POST Error:', error)
            });
    });
};
// Observador del Servidor - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
connection.on("sendMessage", (_response) => {
    console.log(_response.Leyenda);
    console.log("\n\n\n\n");
    console.log(_response.Estado);
    console.log("\n\n\n\n");
    console.log(JSON.parse(_response.Body));
    /*console.log(Json.json());*/
});