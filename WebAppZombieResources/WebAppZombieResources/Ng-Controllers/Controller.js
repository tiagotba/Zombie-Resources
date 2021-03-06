﻿app.controller('RecursosController', function ($scope, APIService, $window) {
    getAll();

    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            $scope.listaRecursos = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.getId = function (idEdited) {
        $window.location.assign("../Recursos/Edit/" + idEdited);
    }

    $scope.controlaSaldos = function (qtdTotal) {

        if (qtdTotal !== null && $scope.QtdDeb > 0) {

            var result = qtdTotal - $scope.QtdDeb;
            $scope.Quantidade = result;
        }
        else {

            $scope.QtdDeb = 0;
            $scope.Quantidade = $scope.qtdBd;
        }

    }


    $scope.saveSubs = function () {
        var rec = {
            Descricao: $scope.desc,
            Quantidade: $scope.qtd,
            Observacao: $scope.obs
        };
        var saveSubs = APIService.saveRecurso(rec);
        saveSubs.then(function (d) {
            getAll();
            alert('Registo alterado com sucesso!!');
            $window.location.assign("../Recursos/");

        }, function (error) {
            alert('um erro ocorreu!!');
            //console.log('Oops! Something went wrong while saving the data.')
        })
    };

    //$scope.editPerson = function (pId)
    //{
    //    for (i in $scope.listaRecursos)
    //    { //Getting the person details from scope based on id 
    //        if ($scope.listaRecursos[i].Id === pId) { //Assigning the Create user scope variable for editing
    //            $scope.newrecurso = { 
    //                Id: $scope.listaRecursos[i].Id,
    //                Descricao: $scope.listaRecursos[i].Descricao,
    //                Quantidade: $scope.listaRecursos[i].Quantidade,
    //                Observacao: $scope.listaRecursos[i].Observacao,
    //                //Gender: JSON.stringify($scope.persons[i].Gender)
    //            }; //Hiding Save button
    //            $scope.DisplaySave = false; //Displaying Update button 
    //            $scope.DisplayUpdate = true; //Clearing the Status 
    //            $scope.status = '';
    //        }


    $scope.editRecurso = function () {

        var path = location.pathname;
        var pos = location.pathname.lastIndexOf("/");
        var id = path.substr(pos + 1);

        var servCall = APIService.editRecurso(id);
        servCall.then(function (d) {
            $scope.Id = d.data.Id,
            $scope.Descricao = d.data.Descricao,
            $scope.Quantidade = d.data.Quantidade,
            $scope.Observacao = d.data.Observacao
            $scope.QtdDeb = 0
            $scope.qtdBd = d.data.Quantidade


        }, function (error) {
            alert('um erro ocorreu!!');
            //$log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.deleteRecurso = function (idDeleted) {

        //deleteRec = $window.confirm('Deseja deletar esse registro?');

        if (confirm('Deseja deletar esse registro?')) {

            var deleteSubs = APIService.delRecurso(idDeleted);

            deleteSubs.then(function (d) {
                alert('Registo deletado com sucesso!!');
                $window.location.reload(true);
                getAll();
            }, function (error) {
                //alert('um erro ocorreu!!');
                mensagemErroModalPopUp(idDeleted, "um erro ocorreu!!");
                //$log.error('Oops! Something went wrong while fetching the data.')
            }

            )
        }

    }


    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };

    $scope.updRecurso = function () {

        var IdUser = document.getElementById('IdUser');
        var Newrec = {
            Id: $scope.Id,
            Descricao: $scope.Descricao,
            Quantidade: $scope.Quantidade,
            Observacao: $scope.Observacao
        };
        var qtdDebitada = {

            Total: $scope.QtdDeb
        };


        var updSubs = APIService.updRecurso(Newrec, Newrec.Id,IdUser.value,qtdDebitada.Total);
        updSubs.then(function (d) {
            alert('Registo alterado com sucesso!!');
            $window.location.reload(true);
            getAll();
        }, function (error) {
            alert('um erro ocorreu!!');
            //console.log('Oops! Something went wrong while saving the data.')
        })
    };

})


app.controller('SobreviventeController', function ($scope, APIService, $window) {

    $scope.Register = function () {

        var sobr = {

            Nome: $scope.nome,
            Idade: $scope.idade,
            LoginName: $scope.login,
            Genero: $scope.sexo.tipo 
        };
        
        var savesobr = APIService.saveSobr(sobr);
        savesobr.then(function (d) {
            alert('Registo alterado com sucesso!!');
            $scope.HashSeguranca = d.data.HashSeguranca;
        }, function (error) {
            alert('um erro ocorreu!!');

        }
        )
    }

    $scope.Login = function () {

        var Hash = {

            HashSeguranca: $scope.HashSeguranca
        }

        var LoginService = APIService.sbrLogin(Hash.HashSeguranca);
        LoginService.then(function (d) {
            if (d.data.Id !== null && d.data.Id > 0) {

                $window.location.assign("../Recursos/?hasSeguranca=" + d.data.HashSeguranca);
            }
            else {
                alert('Hash de login invalido!')
            }
        })

    }
}



)





