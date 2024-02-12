document.addEventListener("DOMContentLoaded", function () {
    var table = document.getElementById('table');
    var dataRows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    var paginationRow = 5;
    var rowTotal = dataRows.length;
    var totalPages = Math.ceil(rowTotal / paginationRow);
    var paginated = document.getElementById('paginated');
    var currentPage = localStorage.getItem('currentPage') || 1;

    for (let i = 1; i <= totalPages; i++) {
        let link = document.createElement('a');
        link.href = '#';
        link.textContent = i;
        link.onclick = function (page) {
            return function () {
                showPage(page);
            };
        }(i);
        paginated.appendChild(link);
    }

    showPage(currentPage);

    function showPage(pageNumber) {
        for (let i = 0; i < dataRows.length; i++) {
            dataRows[i].style.display = 'none';
        }

        let start = (pageNumber - 1) * paginationRow;
        let end = start + paginationRow;
        for (let i = start; i < end && i < rowTotal; i++) {
            dataRows[i].style.display = 'table-row';
        }

        let linkPaginated = document.querySelectorAll('#paginated a');
        linkPaginated.forEach(function (link) {
            link.classList.remove('active');
        });
        linkPaginated[pageNumber - 1].classList.add('active');

        localStorage.setItem('currentPage', pageNumber); // Almacenar la página actual en el localStorage
    }

    function changeRowsByPages() {
        let select = document.getElementById("rowsPerPage");
        paginationRow = parseInt(select.value);
        rowTotal = dataRows.length;
        totalPages = Math.ceil(rowTotal / paginationRow);
        showPage(1);
        updatePaginationLinks();
    }

    function updatePaginationLinks() {
        while (paginated.firstChild) {
            paginated.removeChild(paginated.firstChild);
        }
        for (let i = 1; i <= totalPages; i++) {
            let link = document.createElement('a');
            link.href = '#';
            link.textContent = i;
            link.onclick = function (page) {
                return function () {
                    showPage(page);
                };
            }(i);
            paginated.appendChild(link);
        }
    }

    document.getElementById('rowsPerPage').addEventListener('change', changeRowsByPages);
});
