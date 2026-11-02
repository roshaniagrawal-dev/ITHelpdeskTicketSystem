$(document).ready(function () {
    $("tbody tr").click(function () {
        $("tbody tr").removeClass("table-active");
        $(this).addClass("table-active");
    });

    $("#TicketType").change(function () {
        $(".type-field").hide();
        let ticketTypeId = $(this).val();
        if (ticketTypeId == "1") {
            $('[data-type="hardware"]').show();
        } else if(ticketTypeId == "2") {
            $('[data-type="software"]').show();
        } else if(ticketTypeId == "3") {
            $('[data-type="accessrequest"]').show();
        }
    });
});

