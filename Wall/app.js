var app = angular.module('wall-app', []);

app.controller('mainController', function ($http) {
    this.result = {};
    this.loading = true;

    $http.get('api/test').then(response => {
        this.result = response.data;
        this.loading = false;
    });
});