app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        controller: 'InicioCtrl',
        templateUrl: '/app/modulos/home/views/inicio.html'
    })
    .when('/avaliacao/', {
        controller: 'ListagemAvaliacaoCtrl',
        templateUrl: '/app/modulos/avaliacao/views/ListaAvaliacao.html'
    });
});