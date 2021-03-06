﻿app.service("APIService", function ($http) {
    this.getSubs = function () {
        return $http.get("http://localhost:52675/api/Recursos/")
    }

    this.saveRecurso = function(rec)
    {
                return $http(
            {
                method: 'Post',
                data: rec,
                url: "http://localhost:52675/api/Recursos/"
            });

    }

    this.editRecurso = function (i) {
        return $http.get("http://localhost:52675/api/Recursos/"+i)
    }


    this.updRecurso = function (rec, Id, idUser,qtdDebt) {
        
        //alert("http://localhost:52675/api/Recursos/?id=" + Id + "&idUser="+idUser+"&qtd="+qtdDebt);
        return $http(
        {
            method: 'Put',
            data: rec,
            url: "http://localhost:52675/api/Recursos/?id=" + Id + "&idUser=" + idUser + "&qtd=" + qtdDebt

        });
    }

    this.delRecurso = function (Id) {
        var url = "http://localhost:52675/api/Recursos/" + Id;
        return $http(
        {
            method: 'Delete',
            data: Id,
            url: url
        });
    }

    this.saveSobr = function(sobr)
    {
        return $http(
           {
               method: 'Post',
               data: sobr,
               url: "http://localhost:52675/api/Sobreviventes/"
           });
    }

    this.sbrLogin = function(hash)
    {
        return $http.get("http://localhost:52675/api/Sobreviventes/?id=0&hashId=" + hash)
    }
});