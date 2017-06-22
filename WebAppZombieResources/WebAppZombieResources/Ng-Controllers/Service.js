app.service("APIService", function ($http) {
    this.getSubs = function () {
        return $http.get("http://localhost:52675/api/Recursos/")
    }
});