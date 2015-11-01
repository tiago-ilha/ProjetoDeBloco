
app.controller('InicioCtrl', InicioCtrl);

InicioCtrl.$inject = ['$scope'];

function InicioCtrl($scope) {

    $scope.titulo = 'Sejam bem vindos ao nosso projeto de bloco!';

    $scope.grupo = [
        { nome: 'Eduardo Assunção' },
        { nome: 'Jonas Ribeiro' },
        { nome: 'Tiago de Oliveira' }
    ];
}