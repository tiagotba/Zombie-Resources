app.service("APIService", function ($http) {
    this.getSubs = function () {
        return $http.get("http://localhost:52675/api/Recursos/")
    }

    this.saveRecurso = function(rec)
    {
                return $http(
            {
                method: 'post',
                data: rec,
                url: "http://localhost:52675/api/Recursos/"
            });

    }
});