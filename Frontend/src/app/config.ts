import { app } from './app';

app.config(['$locationProvider', $locationProvider => $locationProvider.html5Mode(true)]);