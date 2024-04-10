// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//Scripts anteriores referenciados

// Este script esta en el final de las páginas de HTML - - - - - - - - - - - - - - - - - - - -
//<script>
//    var BrandEntity = '@_configService["Concept:"ObjetoEnAppSetting.json":Brand"]';
//</script>
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//  ~/js/FrontJS/table/table.js
//  ~/js/ScriptsComponents/Prototypes.js
//  ~/js/FrontJS/Alerts/AlertScript.js
//  ~/lib/microsoft/signalr/dist/browser/signalr.js
//  ~/js/ConnectionSignalR.js
//  ~/js/ConnectionApi.js
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

// Crear el listener del concepto Marca o Tipo
CreateFormsListener(ConceptBrandType);

//Obtener el formulario y aplicar el evento observador
function CreateFormsListener(Prototype) {

    var formulario = document.getElementById(Prototype.Brand);
    if (!formulario)
        return;

    formulario.addEventListener('submit', (event) => {
        // Detener evento de recarga
        event.preventDefault();
        OpenCloseBrand(); // Método global en el archivo forms.js (Cerrar el Forms modal)

        if (!ValidarTodosCampos(formulario)) {
            Modal('¡Campos vacíos!', '¡Por favor, completa todos los campos antes de enviar el formulario.!', false);
            return;
        }

        let Objects = GetFormsData(event);
        // Objeto ViewModel - - - - - - - - - - - -
        let MarcaTipo = {
            Nombre: Objects.Nombre,
            Estado: true,
            Entidad: Objects.Entidad,
            ClientID: uniqueId
        };
        // - - - - - - - - - - - - - - - - - - - - -

        //Petición con la api
        api.SendPost(`api/ComponenteTipo/CreateBrand`, MarcaTipo)
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
connection.on("CreateBrandType", (_response) => {
    if (_response.Estado) {
        NewBrandFile(JSON.parse(_response.Body), ConceptBrandType);
        RefreshBrandInRealTime()
    }

    // Validar la sesión actual para mostrar la alerta solo al cliente que realizó la petición al servidor
    if (_response.ClientID != null && _response.ClientID == uniqueId) {
        AlertaJS(_response); // Mostrar alerta al usuario apropiado
    }
});
 
// Nueva fila de una marca de motores
function NewBrandFile(Records, Prototype) {
    let tbody = document.getElementById(Prototype.Row);

    let id = Records[Records.length - 1].ID;
    let status = Records[Records.length - 1].Estado;
    let name = Records[Records.length - 1].Nombre;
    let entity = BrandEntity; // "BrandEntity" esta definida en la vista, en los scripts

    let tr = document.createElement('tr');
    tr.innerHTML = `
        <tr>
            <td>${name}</td>
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