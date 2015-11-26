$(document).ready(function () {

    $("#btnSair").click(function () {

        var url = "/AutentificarUsuario/Deslogar";

        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            async: true,
            beforeSend: function () {
                waitingDialog.show("Carregando informações....");
            },
            success: function (dados) {                
                waitingDialog.show("Carregando informações....");
                window.location.href = "/Home/Index";                
            },
            error: function () {
                waitingDialog.hide();
            }
        });

    });
});