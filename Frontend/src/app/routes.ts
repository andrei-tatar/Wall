import {app} from './app'

app.config(['$stateProvider', '$urlRouterProvider', ConfigRoutes])

function ConfigRoutes($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('login', {
            url: "/login",
            template: '<wall-login></wall-login>'
        });
}