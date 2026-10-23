$(document).ready(function () {
    $("tbody tr").click(function () {
        $("tbody tr").removeClass("table-active");
        $(this).addClass("table-active");
    });

    $("#searchBox").on("input", function () {
        var text = $(this).val().toLowerCase();

        $("tbody tr").each(function () {
            var rowText = $(this).text().toLowerCase();
            $(this).toggle(rowText.includes(text));
        });
    });
});

