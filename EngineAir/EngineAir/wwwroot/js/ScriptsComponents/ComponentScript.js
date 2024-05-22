
CreateModelVariantListener(ConceptComponent);

//Obtener el formulario y aplicar el evento observador 
function CreateModelVariantListener(Prototype) {
    var formulario = document.getElementById(Prototype.Model);
    if (!formulario)
        return;

    formulario.addEventListener('submit', (event) => {
        // Detener evento de recarga
        event.preventDefault();
        openComponent(); // Método global en el archivo forms.js (Cerrar el Forms modal)

        if (!ValidarTodosCampos(formulario)) {
            Modal('¡Datos no válidos!', '¡Por favor, completa todos los campos antes de enviar el formulario.!', false);
            return;
        }

        let Objects = GetFormsDataTwo(event);

        // Objeto ViewModel - - - - - - - - - - - -
        let componenteViewModel = {
            ModeloVarianteID: Objects.ModeloVarianteID,
            NumSerie: Objects.NumSerie,
            TiempoTotal: Objects.TiempoTotal,
            TURM: Objects.TURM,
            Estado: true,
            Entidad: Objects.Entidad,
            HeliceID: Objects.HeliceID
        };
        // - - - - - - - - - - - - - - - - - - - - -

        //Petición con la api
        api.SendPost(`api/ComponenteTipo/AddComponent`, componenteViewModel)
            .then(_response => {
                if (_response.Estado === false)
                    AlertaJS(_response);
            })
            .catch(error => {
                Modal('¡Sesión expirada!', '¡vuelva a iniciar sesión!', false);
                api.redirectToAction();
            });

    });
};

// Observadores del Servidor - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
connection.on("CreateEngine", (_response) => {
    //if (_response.Estado) {
    //    NewBrandFile(JSON.parse(_response.Body), ConceptBrandType);
    //    RefreshBrandInRealTime()
    //}

    // Validar la sesión actual para mostrar la alerta solo al cliente que realizó la petición al servidor
    //if (_response.ClientID != null && _response.ClientID == uniqueId) {
        AlertaJS(_response); // Mostrar alerta al usuario apropiado
    //}
});

// - - - - - - - - - Funciones para obtener campos del formulario - - - - - - - - -
function GetFormsDataTwo(event) {
    let formData = new FormData(event.target);
    let Objects = {};

    for (let pair of formData.entries()) {
        let key = pair[0].split('.')[1]; // Obtener el nombre del campo sin el prefijo 'Productos.'
        Objects[key] = pair[1];
    }

    return Objects;
}