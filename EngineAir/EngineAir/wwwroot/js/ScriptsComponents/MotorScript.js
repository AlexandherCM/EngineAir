
// Recorrer el objeto donde se contiene la información

Object.keys(Prototypes).forEach(key => {
    const Prototype = Prototypes[key];

    CreateFormsListener(Prototype);
});

//Obtener el contenido de los inputs de un formulario
function GetFormsData(event) {
    const Objetos = {};
    const formData = new FormData(event.target);

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
        var Objects = GetFormsData(event);

        console.log(Objects);

        // Petición con la api
        //api.SendPost(`api/ComponenteTipo/GetMotores`, ViewModel)
        //    .then(data => {

        //    })
        //    .catch(error => {
        //        console.error('POST Error:', error)
        //    });
    });
}
// Evento observador - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -




connection.on("sendMessage", (data) => {

});