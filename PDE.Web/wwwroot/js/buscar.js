$(function () {

    

    const Cargar = (cedula, estructuraId, cargoId, provinciaId) => {

        $.ajax({
            method: "GET",
            url: "/Home/GetMiembros/",
            dataType: "HTML",
            data: { cedula: cedula, estructuraId: estructuraId, cargoId: cargoId, provinciaId: provinciaId }
        }).done(function (data)
        {
             if (data) {

                 $("#tbMiembroContaine").html(data);
             }
        });
    }

    Cargar();

    $('body').on("change","input[name=rdEstructura]",function () {
        var value = $(this).val();

        $.ajax({
            method: "GET",
            url: "/Home/GetCargosByEstructura/",
            data: { estructuraId: value },
            dataType: "Json"
        }).done(function (data) {

                if (data) {

                    $("#CargoId").find('option').remove();
                    $("#CargoId").append('<option >--Seleccione un cargo territorial--</option>');

                    $(data).each(function (i, v) {
                        $("#CargoId").append('<option value="' + v.id + '">' + v.descripcion +'</option>');
                    })

                }
          });

    });

    $("body").on("click", "#btnBuscar", function (e) {

        let cedula = $("#cedula").val();
        let estructuraId = $('input[name=rdEstructura]:checked').val();
        let cargoId = $("#CargoId").val();
        let provinciaId = $("#ProvinciaId").val();
                
        Cargar(cedula, estructuraId, cargoId, provinciaId);

    });

});