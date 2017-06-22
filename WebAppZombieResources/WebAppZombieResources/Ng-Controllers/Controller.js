app.controller('RecursosController', function ($scope, APIService) {
    getAll();

    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            $scope.listaRecursos = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.saveSubs = function () {
        var rec = {
            Desc: $scope.desc,
            Qtd: $scope.qtd,
            Obs: $scope.obs
        };
       
        var saveSubs = APIService.saveRecurso(rec);
        saveSubs.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
})