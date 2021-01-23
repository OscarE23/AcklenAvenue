$(document).ready(function () {

    $("[id*=dgvProductos] tr:has(td)").each(function () {
        var t = $(this).text().toLowerCase(); //all row text
        $("<td class='indexColumn'></td>")
          .hide().text(t).appendTo(this);
    }); //each tr
    $("#Buscar").keyup(function () {

        var s = $(this).val().toLowerCase().split(" ");
        if ($(this).val() == "") {
            s = "";
        }

        $("[id*=dgvProductos] tr:hidden").show();
        $.each(s, function () {

            $("[id*=dgvProductos] tr:visible .indexColumn:not(:contains('"
                  + this + "'))").parent().hide();
        });

    });
});