//document.addEventListener("DOMContentLoaded", function () {
var InitBrandListener = true;

// Restablecer siempre a la primera página después de una actualización.
localStorage.setItem('currentPageBrand', 1); // Almacenar la página actual en el localStorage
PaginatedBrand();

function RefreshBrandInRealTime() {
    let totalRecord = document.getElementById('brand').getElementsByTagName('tbody')[0].getElementsByTagName('tr').length;
    let ddlRowsNumber = parseInt(document.getElementById("rowsPageBrand").value);
    let module = totalRecord % ddlRowsNumber;

    // Si el módulo es 1, significa que el nuevo registro inicia una nueva página
    if (module === 1 || ddlRowsNumber === 1) {
        let paginatedBrand = document.getElementById('paginatedBrand');
        while (paginatedBrand.firstChild) {
            paginatedBrand.removeChild(paginatedBrand.firstChild);
        }

        PaginatedBrand();
    }
}

function PaginatedBrand() {
    let tableBrand = document.getElementById('brand');
    let dataRowsBrand = tableBrand.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    let paginationRowBrand = parseInt(document.getElementById("rowsPageBrand").value);

    let rowTotalBrand = dataRowsBrand.length;
    let totalPagesBrand = Math.ceil(rowTotalBrand / paginationRowBrand);
    let paginatedBrand = document.getElementById('paginatedBrand');
    let currentPageBrand = localStorage.getItem('currentPageBrand') || 1;

    for (let i = 1; i <= totalPagesBrand; i++) {
        let link = document.createElement('a');
        link.href = '#';
        link.textContent = i;
        link.onclick = function (page) {
            return function () {
                showPageBrand(page);
            };
        }(i);
        paginatedBrand.appendChild(link);
    }

    showPageBrand(currentPageBrand);

    function showPageBrand(pageNumber) {
        for (let i = 0; i < dataRowsBrand.length; i++) {
            dataRowsBrand[i].style.display = 'none';
        }

        let start = (pageNumber - 1) * paginationRowBrand;
        let end = start + paginationRowBrand;
        for (let i = start; i < end && i < rowTotalBrand; i++) {
            dataRowsBrand[i].style.display = 'table-row';
        }

        let linkPaginated = document.querySelectorAll('#paginatedBrand a');
        linkPaginated.forEach(function (link) {
            link.classList.remove('active');
        });

        // Verifica si el enlace existe antes de intentar acceder a su classList
        if (linkPaginated.length > 0 && linkPaginated[pageNumber - 1]) {
            linkPaginated[pageNumber - 1].classList.add('active');
        }

        localStorage.setItem('currentPageBrand', pageNumber); // Almacenar la página actual en el localStorage
    }

    function changeRowsByPagesBrand() {
        let select = document.getElementById("rowsPageBrand");
        paginationRowBrand = parseInt(select.value);
        rowTotalBrand = dataRowsBrand.length;
        totalPagesBrand = Math.ceil(rowTotalBrand / paginationRowBrand);
        showPageBrand(1);
        updatePaginationLinksBrand();
    }

    function updatePaginationLinksBrand() {
        while (paginatedBrand.firstChild) {
            paginatedBrand.removeChild(paginatedBrand.firstChild);
        }
        for (let i = 1; i <= totalPagesBrand; i++) {
            let link = document.createElement('a');
            link.href = '#';
            link.textContent = i;
            link.onclick = function (page) {
                return function () {
                    showPageBrand(page);
                };
            }(i);
            paginatedBrand.appendChild(link);
        }
    }

    //Solo crear el listener en la primera carga
    if (InitBrandListener) {
        document.getElementById('rowsPageBrand').addEventListener('change', changeRowsByPagesBrand);
        InitListener = false;
    }
}

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


// Restablecer siempre a la primera página después de una actualización.
var InitModelListener = true;

localStorage.setItem('currentPageModel', 1); // Almacenar la página actual en el localStorage
PaginatedModel();

function RefreshModelInRealTime() {
    let totalRecord = document.getElementById('model').getElementsByTagName('tbody')[0].getElementsByTagName('tr').length;
    let ddlRowsNumber = parseInt(document.getElementById("rowsPageModel").value);
    let module = totalRecord % ddlRowsNumber;

    // Si el módulo es 1, significa que el nuevo registro inicia una nueva página
    if (module === 1 || ddlRowsNumber === 1) {
        let paginatedModel = document.getElementById('paginatedModel');
        while (paginatedModel.firstChild) {
            paginatedModel.removeChild(paginatedModel.firstChild);
        }

        PaginatedModel();
    }
}

function PaginatedModel() {
    // Para la tabla del modelo
    let tableModel = document.getElementById('model');
    let dataRowsModel = tableModel.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    let paginationRowModel = parseInt(document.getElementById("rowsPageModel").value);

    let rowTotalModel = dataRowsModel.length;
    let totalPagesModel = Math.ceil(rowTotalModel / paginationRowModel);
    let paginatedModel = document.getElementById('paginatedModel');
    let currentPageModel = localStorage.getItem('currentPageModel') || 1;

    for (let i = 1; i <= totalPagesModel; i++) {
        let link = document.createElement('a');
        link.href = '#';
        link.textContent = i;
        link.onclick = function (page) {
            return function () {
                showPageModel(page);
            };
        }(i);
        paginatedModel.appendChild(link);
    }

    showPageModel(currentPageModel);

    function showPageModel(pageNumber) {
        for (let i = 0; i < dataRowsModel.length; i++) {
            dataRowsModel[i].style.display = 'none';
        }

        let start = (pageNumber - 1) * paginationRowModel;
        let end = start + paginationRowModel;
        for (let i = start; i < end && i < rowTotalModel; i++) {
            dataRowsModel[i].style.display = 'table-row';
        }

        let linkPaginated = document.querySelectorAll('#paginatedModel a');
        linkPaginated.forEach(function (link) {
            link.classList.remove('active');
        });

        // Verifica si el enlace existe antes de intentar acceder a su classList
        if (linkPaginated.length > 0 && linkPaginated[pageNumber - 1]) {
            linkPaginated[pageNumber - 1].classList.add('active');
        }

        localStorage.setItem('currentPageModel', pageNumber); // Almacenar la página actual en el localStorage
    }

    function changeRowsByPagesModel() {
        let select = document.getElementById("rowsPageModel");
        paginationRowModel = parseInt(select.value);
        rowTotalModel = dataRowsModel.length;
        totalPagesModel = Math.ceil(rowTotalModel / paginationRowModel);
        showPageModel(1);
        updatePaginationLinksModel();
    }

    function updatePaginationLinksModel() {
        while (paginatedModel.firstChild) {
            paginatedModel.removeChild(paginatedModel.firstChild);
        }
        for (let i = 1; i <= totalPagesModel; i++) {
            let link = document.createElement('a');
            link.href = '#';
            link.textContent = i;
            link.onclick = function (page) {
                return function () {
                    showPageModel(page);
                };
            }(i);
            paginatedModel.appendChild(link);
        }
    }

    //Solo crear el listener en la primera carga
    if (InitModelListener) {
        document.getElementById('rowsPageModel').addEventListener('change', changeRowsByPagesModel);
        InitListener = false;
    }
}

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

var InitComponentListener = true;

localStorage.setItem('currentPageTable', 1); // Almacenar la página actual en el localStorage
PaginatedConcept();

function RefreshModelInRealTime() {
    let totalRecord = document.getElementById('table').getElementsByTagName('tbody')[0].getElementsByTagName('tr').length;
    let ddlRowsNumber = parseInt(document.getElementById("rowsPageTable").value);
    let module = totalRecord % ddlRowsNumber;

    // Si el módulo es 1, significa que el nuevo registro inicia una nueva página
    if (module === 1 || ddlRowsNumber === 1) {
        let paginatedComponente = document.getElementById('paginatedTable');
        while (paginatedComponente.firstChild) {
            paginatedComponente.removeChild(paginatedComponente.firstChild);
        }

        PaginatedModel();
    }
}

function PaginatedConcept() {
    // Para la tabla de la tabla
    let tableTable = document.getElementById('table');
    let dataRowsTable = tableTable.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    let paginationRowTable = 5;
    let rowTotalTable = dataRowsTable.length;
    let totalPagesTable = Math.ceil(rowTotalTable / paginationRowTable);
    let paginatedTable = document.getElementById('paginatedTable');
    let currentPageTable = localStorage.getItem('currentPageTable') || 1;

    for (let i = 1; i <= totalPagesTable; i++) {
        let link = document.createElement('a');
        link.href = '#';
        link.textContent = i;
        link.onclick = function (page) {
            return function () {
                showPageTable(page);
            };
        }(i);
        paginatedTable.appendChild(link);
    }

    showPageTable(currentPageTable);

    function showPageTable(pageNumber) {
        for (let i = 0; i < dataRowsTable.length; i++) {
            dataRowsTable[i].style.display = 'none';
        }

        let start = (pageNumber - 1) * paginationRowTable;
        let end = start + paginationRowTable;
        for (let i = start; i < end && i < rowTotalTable; i++) {
            dataRowsTable[i].style.display = 'table-row';
        }

        let linkPaginated = document.querySelectorAll('#paginatedTable a');
        linkPaginated.forEach(function (link) {
            link.classList.remove('active');
        });
        linkPaginated[pageNumber - 1].classList.add('active');

        localStorage.setItem('currentPageTable', pageNumber); // Almacenar la página actual en el localStorage
    }

    function changeRowsByPagesTable() {
        let select = document.getElementById("rowsPageTable");
        paginationRowTable = parseInt(select.value);
        rowTotalTable = dataRowsTable.length;
        totalPagesTable = Math.ceil(rowTotalTable / paginationRowTable);
        showPageTable(1);
        updatePaginationLinksTable();
    }

    function updatePaginationLinksTable() {
        while (paginatedTable.firstChild) {
            paginatedTable.removeChild(paginatedTable.firstChild);
        }
        for (let i = 1; i <= totalPagesTable; i++) {
            let link = document.createElement('a');
            link.href = '#';
            link.textContent = i;
            link.onclick = function (page) {
                return function () {
                    showPageTable(page);
                };
            }(i);
            paginatedTable.appendChild(link);
        }
    }

    //Solo crear el listener en la primera carga
    if (InitComponentListener) {
        document.getElementById('rowsPageTable').addEventListener('change', changeRowsByPagesTable);
        InitListener = false;
    }

}
//});