$(function () {


    $("body").on("click", "#delete", function (e) {

        let Id = $(this).data("id");

        if (confirm("Desea borrar el registro seleccionado?")) {
            $.ajax({
                method: "POST",
                url: "/CargoTerritorials/Delete/",
                data: { id: Id }
            })
                .done(function (data) {

                });
        }

    });

});