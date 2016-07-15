import * as angular from 'angular';
import 'angular-material';
import 'angular-messages';
import 'angular-ui-router';

var app = angular.module('wall-app', ['ngMaterial', 'ui.router', 'ngMessages']);
export { app };

import './config';
import './routes';
import './components/components';
