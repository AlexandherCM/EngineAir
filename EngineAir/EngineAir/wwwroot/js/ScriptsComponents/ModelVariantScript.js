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
            ClientID: uniqueId
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

// Observadores del Servidor - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
connection.on("CreateModelVariant", (_response) => {
    if (_response.Estado) {
        NewBrandFile(JSON.parse(_response.Body), ConceptModelVariant);
        RefreshModelInRealTime()
    }

    // Validar la sesión actual para mostrar la alerta solo al cliente que realizó la petición al servidor
    if (_response.ClientID != null && _response.ClientID == uniqueId) {
        AlertaJS(_response); // Mostrar alerta al usuario apropiado
    }
});

// Nueva fila de un modelos o variente
function NewBrandFile(Records, Prototype) {
    let tbody = document.getElementById(Prototype.Row);

    let id = Records[Records.length - 1].ID;
    let status = Records[Records.length - 1].Estado;
    let name = Records[Records.length - 1].Nombre;

    let nameBrand;
    try {
        nameBrand = Records[Records.length - 1].Marca.Nombre;
    } catch {
        // Bloque de código a ejecutar en caso de que ocurra un error
        nameBrand = Records[Records.length - 1].Tipo.Nombre;
    }

    let timeHrs = Records[Records.length - 1].TiempoRemplazoHrs;
    let timeMounts = Records[Records.length - 1].TiempoRemplazoMeses;
    let entity = ModelEntity; // "ModelEntity" esta definida en la vista, en los scripts

    let tr = document.createElement('tr');
    tr.innerHTML = `
        <tr>
            <td>${nameBrand}</td>
            <td>${name}</td>
            <td>${timeHrs}</td>
            <td>${timeMounts}</td>
            <td>
                <label class="toggle-switch my-2">
                    <input data-id="${id}" data-entity="${entity}"
                            class="chbTable chbUpdateStatus" type="checkbox" checked="${status}">
                    <div class="toggle-switch-background">
                        <div class="toggle-switch-handle"></div>
                    </div>
                </label>
            </td>
            <td>
                <img src="../../images/svg/pen-to-square-regular.svg" class="table-icon"/>
            </td>
        </tr>
    `;

    tbody.appendChild(tr);
    NewEventListenerChbx(tbody);
};

function NewEventListenerChbx(tbody) {
    let rows = Array.from(tbody.children).filter(child => child.tagName.toLowerCase() === 'tr');
    let LastRow = rows[rows.length - 1];

    let chbx = LastRow.querySelector('input[type="checkbox"]');
    CreateChbxListener(chbx);
};