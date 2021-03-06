function fnFormatDetails(oTable, nTr) {
    var aData = oTable.fnGetData(nTr);
    var sOut = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
    sOut += '<tr><td>Detail:</td><td> <a title="Detay" href="/Admin/Category/CategoryDetail/' + aData[1] + '">' + aData[2] + ' </a>(Detay sayfası yok dikkat!!)   </td></tr>';
    sOut += '<tr><td>Product List:</td><td><a title="İçerik" href="/Admin/Product/ProductList/' + aData[1] + '">' + aData[2] + ' </a></td></tr>';

    sOut += '</table>';

    return sOut;
}

$(document).ready(function () {
    /*
     * Insert a 'details' column to the table
     */
    var nCloneTh = document.createElement('th');
    var nCloneTd = document.createElement('td');
    nCloneTd.innerHTML = '<img src="/OuterTools/assets/advanced-datatable/examples/examples_support/details_open.png">';
    nCloneTd.className = "center";

    $('#hidden-table-info thead tr').each(function () {
        this.insertBefore(nCloneTh, this.childNodes[0]);
    });

    $('#hidden-table-info tbody tr').each(function () {
        this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
    });

    /*
     * Initialse DataTables, with no sorting on the 'details' column
     */
    var oTable = $('#hidden-table-info').dataTable({
        "aoColumnDefs": [
            { "bSortable": false, "aTargets": [0] }
        ],
        "aaSorting": [[1, 'asc']]
    });

    /* Add event listener for opening and closing details
     * Note that the indicator for showing which row is open is not controlled by DataTables,
     * rather it is done here
     */
    $('#hidden-table-info tbody td img').live('click', function () {
        var nTr = $(this).parents('tr')[0];
        if (oTable.fnIsOpen(nTr)) {
            /* This row is already open - close it */
            this.src = "/OuterTools/assets/advanced-datatable/examples/examples_support/details_open.png";
            oTable.fnClose(nTr);
        }
        else {
            /* Open this row */
            this.src = "/OuterTools/assets/advanced-datatable/examples/examples_support/details_close.png";
            oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
        }
    });
});

function ShowDialog(a) {
    if (!confirm('Are you sure you want to delete the ' + a + ' ?')) { return false } else { return alert(a + ' deleted') }
}



