function clearFilters() {
    var form = document.getElementById('filterForm');

    var dropdowns = form.getElementsByClassName('custom-dropdown');
    for (var i = 0; i < dropdowns.length; i++) {
        var dropdown = dropdowns[i].getElementsByTagName('select')[0];
        dropdown.selectedIndex = 0;
    }

    var hiddenInputs = form.getElementsByTagName('input');
    for (var i = 0; i < hiddenInputs.length; i++) {
        hiddenInputs[i].value = '';
    }

    form.submit();
}

function clearFilters2() {
    document.getElementById('SearchFilter').value = '';

    var dropdowns = document.getElementsByClassName('select-item');
    for (var i = 0; i < dropdowns.length; i++) {
        var select = dropdowns[i];
        select.selectedIndex = 0;
    }

    var form = document.getElementById('filterForm');
    if (form) {
        form.submit();
    }
}

function submitFilterForm() {
    document.getElementById("filterForm").submit();
//    document.getElementById("searchForm").elements["txtSearchFilter"].value = document.getElementById("txtSearchFilter").value;
//    document.getElementById("searchForm").elements["filterPoziom"].value = document.getElementById("filterPoziom").value;
//    document.getElementById("searchForm").elements["filterForma"].value = document.getElementById("filterForma").value;
//    document.getElementById("searchForm").elements["filterJezyk"].value = document.getElementById("filterJezyk").value;
//    document.getElementById("searchForm").elements["filterWydzial"].value = document.getElementById("filterWydzial").value;
//    document.getElementById("searchForm").elements["filterMiejsce"].value = document.getElementById("filterMiejsce").value;
}

function submitWydzialForm() {
    document.getElementById("wydzialForm").submit();
}

function ograniczWartosciMinMax(element) {

    if (element.value > 100) {
        element.value = 100;
    }
    if (element.value < 0){
        element.value = 0;
    }
}
function ograniczWartosciMinMaxEgzRys(element) {

    if (element.value > 660) {
        element.value = 660;
    }
    if (element.value < 0){
        element.value = 0;
    }
}

function clearFilters() {
    var form = document.getElementById('filterForm');

    var dropdowns = form.getElementsByClassName('custom-dropdown');
    for (var i = 0; i < dropdowns.length; i++) {
        var dropdown = dropdowns[i].getElementsByTagName('select')[0];
        dropdown.selectedIndex = 0;
    }

    var hiddenInputs = form.getElementsByTagName('input');
    for (var i = 0; i < hiddenInputs.length; i++) {
        hiddenInputs[i].value = '';
    }

    form.submit();
}

function showPopup(content) {
    $("#confirmationModal .modal-body").text(content);
    $('#confirmationModal').modal('show');
}

function submitSortForm() {
    var sortOptionValue = document.getElementById("sortOption").value;
    document.getElementById("sortForm").submit();
    document.getElementById("searchForm").elements["sortOption"].value = sortOptionValue;
}

