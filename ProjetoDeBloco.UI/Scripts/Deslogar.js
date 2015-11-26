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
                window.location.href = "/Home/Index";
                toastr.success(dados.mensagem, "Sucesso");
            },
            error: function () {
                waitingDialog.hide();
            }
        });

    });
});