// Genera un identificador único para esta sesión de cliente (MOMENTÁNEO)
const uniqueId = Date.now().toString() + Math.random().toString(36).substring(2, 9);

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
let chbxBrandsTypes = document.querySelectorAll('.chbUpdateStatus');
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
        api.SendPost(`api/ComponenteTipo/UpdateBrandStatus`, UpdateStatusDTO)
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
connection.on("updateStatus", (obj) => {
    //Recargar valores para detectar nuevas filas
    chbxBrandsTypes = document.querySelectorAll('.chbUpdateStatus');

    chbxBrandsTypes.forEach((chbx) => {
        let id = chbx.getAttribute('data-id');
        let entity = chbx.getAttribute('data-entity');

        if (parseInt(id) === obj.ID && entity === obj.Entidad)
            chbx.checked = Boolean(obj.Status);
    });
});
