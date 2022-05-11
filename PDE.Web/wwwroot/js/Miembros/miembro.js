$(function () {

    $("#SupervisorId").append('<option value="0" >--Seleccione un supervisor--</option>');
    $("#CargoId").append('<option >--Seleccione un cargo territorial--</option>');

    $("body").on("click", "#buscarCedula", function (e) {

        let cedula = $("#txtCedula").val();

        $.ajax({
            method: "GET",
            url: "/Miembros/ConsultarPadron",
            data: { cedula: cedula },
            dataType: "HTML"
        })
        .done(function (data) {

           if (data) {

               $("#conteinerForm").html(data);
           }
        });

    });


    $("body").on("change", "#LocalidadId", function (e) {

        let LocalidadId = $(this).val();

        $.ajax({
            method: "GET",
            url: "/Miembros/GetCargosByLocalidad/",
            data: { localidadId: LocalidadId },
            //dataType: "Json"
        })
            .done(function (data) {
                
            if (data) {               
                
                $("#CargoId").find('option').remove();
                $("#CargoId").append('<option >--Seleccione un cargo territorial--</option>');
                $("#SupervisorId").find('option').remove();
                $("#SupervisorId").append('<option value="0">--Seleccione un supervisor--</option>');
                $(data).each(function (i, v) {
                    $("#CargoId").append('<option value="' + v.cargo.id + '">' + v.cargo.descripcion + '</option>');
                })

            }
        });

    });

    $("body").on("change", "#CargoId", function (e) {

        let cargoId = $(this).val();
        let localidadId = $("#LocalidadId").val();
        let provinciaId = $("#ProvinciaId").val();

        $.ajax({
            method: "GET",
            url: "/Miembros/GetSupervisorByCargo/",
            data: { CargoId: cargoId, LocalidadId: localidadId },
            dataType: "Json"
        })
            .done(function (data) {

                if (data) {

                   $("#SupervisorId").find('option').remove();
                    $("#SupervisorId").append('<option value="0" >--Seleccione un supervisor--</option>');

                    $(data).each(function (i, v) {
                        $("#SupervisorId").append('<option value="' + v.id + '">' + v.nombres+ " "+v.apellidos + '</option>');
                    })

                }
            });

    });



});