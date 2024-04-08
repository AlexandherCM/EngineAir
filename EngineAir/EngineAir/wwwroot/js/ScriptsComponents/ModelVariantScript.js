//</script>
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//  ~/js/FrontJS/table/table.js
//  ~/js/ScriptsComponents/Prototypes.js
//  ~/js/FrontJS/Alerts/AlertScript.js
//  ~/lib/microsoft/signalr/dist/browser/signalr.js
//  ~/js/ConnectionSignalR.js
//  ~/js/ConnectionApi.js
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
CreateModelVariantListener(ConceptModelVariant);

//Obtener el formulario y aplicar el evento observador 
function CreateModelVariantListener(Prototype) {
    var formulario = document.getElementById(Prototype.Model);
    if (!formulario)
        return;

    formulario.addEventListener('submit', (event) => {
        // Detener evento de recarga
        event.preventDefault();
        openCloseModel(); // Método global en el archivo forms.js (Cerrar el Forms modal)

        let flagOne = ValidarTodosCampos(formulario);
        let object = ValidarTodosCamposModelo(formulario);
        let flagTwo = object.Estado;

        if (!flagOne || !flagTwo) {
            let leyenda;

            if (!flagTwo)
                leyenda = object.Leyenda;

            if (!flagOne)
                leyenda = '¡Por favor, completa todos los campos obligatorios antes de enviar el formulario.!';

            Modal('¡Campos vacíos!', leyenda, false);
            return;
        }

        let Objects = GetFormsData(event);
        // Objeto ViewModel - - - - - - - - - - - -
        let ModeloVariante = {
            Entidad: Objects.Entidad,
            MarcaTipoID: parseInt(Objects.MarcaTipoID),
            Nombre: Objects.Nombre,
            TiempoRemplazoHrs: parseInt(Objects.TiempoRemplazoHrs),
            UnidadTiempo: Objects.UnidadTiempo === 'true' ? true : false,
            Cantidad: parseInt(Objects.Cantidad),
            Estado: true,
        };
        // - - - - - - - - - - - - - - - - - - - - -

        //Petición con la api
        api.SendPost(`api/ComponenteTipo/CreateModelVariant`, ModeloVariante)
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