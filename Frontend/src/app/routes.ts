import {app} from './app'

app.config(ConfigRoutes)

ConfigRoutes.$inject = ['$stateProvider', '$urlRouterProvider'];
function ConfigRoutes(stateProvider: ng.ui.IStateProvider, urlRouterProvider: ng.ui.IUrlRouterProvider) {
    stateProvider
        .state('login', {
            url: '/login',
            template: '<wall-login></wall-login>'
        })
        .state('register', {
            url: '/register',
            template: '<wall-register></wall-register>'
        })
        .state('home', {
            url: '/',
            views: {
                '': {template: '<wall-home></wall-home>'},
                'toolbar': {template: '<wall-toolbar></wall-toolbar>'}
            }
        });

    urlRouterProvider.otherwise('/');
}