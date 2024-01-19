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

function submitFilterForm() {
    document.getElementById("filterForm").submit();
    document.getElementById("searchForm").elements["filterPoziom"].value = document.getElementById("filterPoziom").value;
    document.getElementById("searchForm").elements["filterForma"].value = document.getElementById("filterForma").value;
    document.getElementById("searchForm").elements["filterJezyk"].value = document.getElementById("filterJezyk").value;
    document.getElementById("searchForm").elements["filterWydzial"].value = document.getElementById("filterWydzial").value;
    document.getElementById("searchForm").elements["filterMiejsce"].value = document.getElementById("filterMiejsce").value;
}

function ograniczDoMaksimum(element) {

    if (element.value > 100) {
        element.value = 100;
    }
    if (element.value < 0){
        element.value = 0;
    }
}