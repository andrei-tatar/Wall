import * as angular from 'angular';
import 'angular-material';

var app = angular.module('app', ['ngMaterial']);
export { app };

app.value('apiUri', 'http://localhost:50001/');

import './main';