app.controller('ListagemAvaliacaoCtrl', AvaliacaoCtrl);

AvaliacaoCtrl.$inject = ['$scope', 'AvaliacaoRepositorio'];

function AvaliacaoCtrl($scope, AvaliacaoRepositorio) {

    $scope.titulo = 'Listagem de Avaliações';

    $scope.avaliacoes = [];

    CarregarAvaliacoes();

    function CarregarAvaliacoes() {
        AvaliacaoRepositorio.query(function (avaliacoes) {
            $scope.avaliacoes = avaliacoes;
            console.log(avaliacoes);
        });
    }
}


app.factory('AvaliacaoRepositorio', AvaliacaoRepositorio);

AvaliacaoRepositorio.$inject = ['$resource'];

function AvaliacaoRepositorio($resource) {
    return $resource('http://localhost:50426/api/Avaliacao/:id', { id: '@id' }, {
        enivarEmail: { method: 'post' }
    });
}