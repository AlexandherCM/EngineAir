//document.addEventListener("DOMContentLoaded", function () {
var InitListener = true;
PaginatedBrand();

function RefreshInRealTime() {
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
    var tableBrand = document.getElementById('brand');
    var dataRowsBrand = tableBrand.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    var paginationRowBrand = parseInt(document.getElementById("rowsPageBrand").value);

    var rowTotalBrand = dataRowsBrand.length;
    var totalPagesBrand = Math.ceil(rowTotalBrand / paginationRowBrand);
    var paginatedBrand = document.getElementById('paginatedBrand');
    var currentPageBrand = localStorage.getItem('currentPageBrand') || 1;

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
        linkPaginated[pageNumber - 1].classList.add('active');

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
    if (InitListener) {
        document.getElementById('rowsPageBrand').addEventListener('change', changeRowsByPagesBrand);
        InitListener = false;
    }
}

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

// Para la tabla del modelo
var tableModel = document.getElementById('model');
var dataRowsModel = tableModel.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
var paginationRowModel = 5;
var rowTotalModel = dataRowsModel.length;
var totalPagesModel = Math.ceil(rowTotalModel / paginationRowModel);
var paginatedModel = document.getElementById('paginatedModel');
var currentPageModel = localStorage.getItem('currentPageModel') || 1;

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
    linkPaginated[pageNumber - 1].classList.add('active');

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

document.getElementById('rowsPageModel').addEventListener('change', changeRowsByPagesModel);


// Para la tabla de la tabla
var tableTable = document.getElementById('table');
var dataRowsTable = tableTable.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
var paginationRowTable = 5;
var rowTotalTable = dataRowsTable.length;
var totalPagesTable = Math.ceil(rowTotalTable / paginationRowTable);
var paginatedTable = document.getElementById('paginatedTable');
var currentPageTable = localStorage.getItem('currentPageTable') || 1;

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

document.getElementById('rowsPageTable').addEventListener('change', changeRowsByPagesTable);
//});