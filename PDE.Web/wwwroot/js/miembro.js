$(function () {


    $("body").on("click", "#buscarCedula", function (e) {

        let cedula = $("#txtCedula").val();

        $.ajax({
            method: "GET",
            url: "/Miembros/ConsultarPadron",
            data: { cedula: cedula },
            //dataType: "HTML"
        })
       .done(function (data) {
           if (data) {
               console.log(data);
               $("#conteinerForm").html(data);
           }
        });

    });

});