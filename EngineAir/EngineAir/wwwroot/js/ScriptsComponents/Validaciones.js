
function ValidarTodosCampos(formulario) {
    let EstadoFormulario = true;
    let inputs = formulario.querySelectorAll('input[type="text"], input[type="number"], select');

    inputs.forEach(function (input) {
        // Si no tiene la clase 'posibleNull', aplicamos la validación
        if (!input.value && !input.classList.contains('possibleNull')) {
            EstadoFormulario = false;
            input.style.border = '2px solid red';
        } else {
            input.style.border = '';
        }
    });

    return EstadoFormulario;
};

function ValidarTodosCamposModelo(formulario) {
    let EstadoFormulario = false;
    let leyenda;

    let banderaUno = false; // Evaluar campo TiempoRemplazoHrs
    let banderaDos = false; // Evaluar campos que definen el plazo de tiempo en meses

    // Validación personalizada para UnidadTiempo y Cantidad
    let UnidadTiempo = formulario.querySelector('select[name="UnidadTiempo"]');
    let Cantidad = formulario.querySelector('input[name="Cantidad"]');
    let TiempoRemplazoHrs = formulario.querySelector('input[name="TiempoRemplazoHrs"]');

    // Resetear estilos por defecto antes de la validación
    UnidadTiempo.style.border = '';
    Cantidad.style.border = '';
    TiempoRemplazoHrs.style.border = '';

    if (TiempoRemplazoHrs.value)
        banderaUno = true;
    else {
        banderaUno = false;
    }

    if (Cantidad.value && UnidadTiempo.value !== '')
        banderaDos = true;
    else if (!Cantidad.value && UnidadTiempo.value !== '') {
        banderaDos = false;
        banderaUno = false;
        Cantidad.style.border = '2px solid red';

        leyenda = '¡Especifica la cantidad de meses o años.!'
    }
    else if (Cantidad.value && UnidadTiempo.value === '') {
        banderaDos = false;
        banderaUno = false;
        UnidadTiempo.style.border = '2px solid red';

        leyenda = '¡Especifica la unidad de medida en meses o años.!'
    }

    if (!TiempoRemplazoHrs.value && !Cantidad.value && !UnidadTiempo.value) {
        TiempoRemplazoHrs.style.border = '2px solid red';
        UnidadTiempo.style.border = '2px solid red';
        Cantidad.style.border = '2px solid red';
        leyenda =
            '¡Debes de proporcionar almenos uno de los dos conceptos de tiempo de remplazo,!'
    }

    if (banderaUno || banderaDos) {
        TiempoRemplazoHrs.style.border = '';
        UnidadTiempo.style.border = '';
        Cantidad.style.border = '';
    }

    return {
        Estado : banderaUno || banderaDos ? true : false,
        Leyenda : leyenda
    };
};

// Inputs
const ddlUnidadTiempo = document.getElementById('ddlUnidadTiempo');
const txtCantidad = document.getElementById('txtCantidad');
function UpdateCount() {
    return parseInt(txtCantidad.value);
}

ddlUnidadTiempo.addEventListener('change', ValidarPeriodo);
txtCantidad.addEventListener('input', ValidarPeriodo);

function ValidarPeriodo() {
    ValidarRango(20);
    if (ddlUnidadTiempo.value !== "true")
        return;

    if (UpdateCount() === 12) {
        ddlUnidadTiempo.value = 'false';
        txtCantidad.value = 1;
    }
    else if (UpdateCount() >= 12)
        ddlUnidadTiempo.value = 'false';
}

function ValidarRango(limit) {
    if (UpdateCount() < 1 || UpdateCount() > limit) {
        txtCantidad.value = 1;
    }
}


