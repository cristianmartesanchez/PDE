$(function () {

    $("#SupervisorId").append('<option value="0" >--Seleccione un supervisor--</option>');
    $("#CargoTerritorialId").append('<option>--Seleccione un Cargo Territorial--</option>');

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
        }).done(function (data) {
                
            if (data) {

                $("#CargoTerritorialId").find('option').remove();
                $("#CargoTerritorialId").append('<option >--Seleccione un Cargo Territorial--</option>');
                $("#SupervisorId").find('option').remove();
                $("#SupervisorId").append('<option value="0">--Seleccione un supervisor--</option>');

                $(data).each(function (i, v) {
                    $("#CargoTerritorialId").append('<option value="' + v.id + '">' + v.cargo.descripcion + '</option>');
                });

            }
        });

    });

    $("body").on("change", "#CargoTerritorialId", function (e) {

        let cargoId = $(this).val();
        let localidadId = $("#LocalidadId").val();

        $.ajax({
            method: "GET",
            url: "/Miembros/GetSupervisorByCargo/",
            data: { CargoTerritorialId: cargoId, LocalidadId: localidadId },
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