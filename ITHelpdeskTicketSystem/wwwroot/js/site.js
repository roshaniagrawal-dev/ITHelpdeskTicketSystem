$(document).ready(function () {
    $("tbody tr").click(function () {
        $("tbody tr").removeClass("table-active");
        $(this).addClass("table-active");
    });

});

