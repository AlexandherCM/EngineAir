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

// Genera un identificador único para esta sesión de cliente (MOMENTÁNEO)
const uniqueId = Date.now().toString() + Math.random().toString(36).substring(2, 9);

// Recorrer el objeto donde se contiene la información
Object.keys(Prototypes).forEach(key => {
    const Prototype = Prototypes[key];

    CreateFormsListener(Prototype);
});

//Obtener el contenido de los inputs de un formulario
function GetFormsData(event) {
    let Objetos = {};
    let formData = new FormData(event.target);

    formData.forEach((value, key) => {
        Objetos[key] = value;
    });
    return Objetos;
};

// Eventos observador - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
//Obtener todos los chbox del concepto marca o tipo y agregar la función de update
let chbxBrandsTypes = document.querySelectorAll('.chbBrandType');
chbxBrandsTypes.forEach((chbx) => {
    CreateChbxListener(chbx);
});

function CreateChbxListener(chbx) {
    chbx.addEventListener('change', (event) => {
        let id = event.currentTarget.getAttribute('data-id');
        let entity = event.currentTarget.getAttribute('data-entity');

        // Objeto DTO - - - - - - - - - - - -
        let UpdateStatusDTO = {
            ID: parseInt(id),
            Entidad: entity
        };

        //Petición con la api
        api.SendPost(`api/ComponenteTipo/UpdateStatus`, UpdateStatusDTO)
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

//Obtener el formulario y aplicar el evento observador
function CreateFormsListener(Prototype) {
    if (!document.getElementById(Prototype.Brand))
        return;

    document.getElementById(Prototype.Brand).addEventListener('submit', (event) => {
        // Detener evento de recarga
        event.preventDefault();
        OpenCloseBrand(); // Método global en el archivo forms.js (Cerrar el Forms modal)

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
        api.SendPost(`api/ComponenteTipo/Create`, MarcaTipo)
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
        NewBrandFile(JSON.parse(_response.Body), Prototypes);
        RefreshBrandInRealTime()
    }

    // Validar la sesión actual para mostrar la alerta solo al cliente que realizó la petición al servidor
    if (_response.ClientID != null && _response.ClientID == uniqueId) {
        AlertaJS(_response); // Mostrar alerta al usuario apropiado
    }
});

connection.on("updateStatus", (obj) => {
    //Recargar valores para detectar nuevas filas
    chbxBrandsTypes = document.querySelectorAll('.chbBrandType');

    chbxBrandsTypes.forEach((chbx) => {
        let id = chbx.getAttribute('data-id');
        let entity = chbx.getAttribute('data-entity');

        if (parseInt(id) === obj.ID && entity === obj.Entidad)
            chbx.checked = Boolean(obj.Status);
    });
});

// Nueva fila de una marca de motores
function NewBrandFile(Records, Prototypes) {
    let tbody = document.getElementById(Prototypes.ConceptBrandType.Row);

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
                           class="chbTable chbBrandType" type="checkbox" checked="${status}">

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
