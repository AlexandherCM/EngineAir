
CreateModelVariantListener(ConceptComponent);

//Obtener el formulario y aplicar el evento observador 
function CreateModelVariantListener(Prototype) {
    var formulario = document.getElementById(Prototype.Component);
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
            HeliceID: Objects.HeliceID,
            ClientID: uniqueId
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
    if (_response.Estado) { 
        NewComponentFile(JSON.parse(_response.Body), ConceptComponent);
        RefreshBrandInRealTime()
    } 

    // Validar la sesión actual para mostrar la alerta solo al cliente que realizó la petición al servidor
    if (_response.ClientID != null && _response.ClientID == uniqueId) {
        AlertaJS(_response); // Mostrar alerta al usuario apropiado
    }
});

function NewComponentFile(Records, Prototype) {
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