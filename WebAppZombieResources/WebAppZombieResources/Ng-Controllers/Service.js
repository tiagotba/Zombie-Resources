app.service("APIService", function ($http) {
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


    this.updRecurso = function (rec,Id) {
        return $http(
        {
            method: 'Put',
            data: rec,
            url: "http://localhost:52675/api/Recursos/"+Id
        });
    }
});