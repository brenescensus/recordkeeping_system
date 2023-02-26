// remove active class
const list = document.querySelectorAll('.list')
function activeLink() {
    list.forEach((item) =>
        item.classList.remove('active'));
    this.classList.add('active');
    debugger
    let id = this.getAttribute("id");
    sessionStorage.setItem("side-nav", id);

}
list.forEach((item) =>
    item.addEventListener('click', activeLink));

//change active class
debugger
const sideNav = sessionStorage.getItem("side-nav");
if (sideNav) {
    list.forEach((item) =>
        item.classList.remove('active'));
    const elem = document.getElementById(sideNav);
    elem.classList.add('active');
}

function showMenu() {
    var showDropMenu = document.getElementById("show-dropdown");
    if (showDropMenu.style.display == "none") {
        showDropMenu.style.display = "block";
    }
    else {
        showDropMenu.style.display = "none"
    }
}

$('#availabletask thead tr')
    .clone(true)
    .addClass('filters')
    .appendTo('#availabletask thead');
var TaskTable = $('#availabletask').DataTable({
    responsive: true,
    "sDom": "lfrti",
    "dom": '<"top"if>rt<"bottom"lp><"">',
    oLanguage: {
        oPaginate: {
            sNext: '<span class="pagination-fa"><i class="fa fa-chevron-right" ></i></span>',
            sPrevious: '<span class="pagination-fa"><i class="fa fa-chevron-left" ></i></span>'
        }
    },
    orderCellsTop: false,
    initComplete: function () {
        this.api().columns().every(function () {
            var column = this;
            var select = $('<select><option value=""></option></select>')
                .appendTo($("#availabletask thead tr:eq(1) th").eq(column.index()).empty())
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );
                    column
                        .search(val ? '^' + val + '$' : '', true, false)
                        .draw();
                });
            column.data().unique().sort().each(function (d, j) {
                select.append('<option value="' + d + '">' + d + '</option>');
            });
        });
    }

});

$("#availabletask_filter").hide();
$("#availabletask_info").hide();
$(".previous-page").hide();

$('#searchdata').keyup(function () {
    TaskTable.search($(this).val()).draw();
})



