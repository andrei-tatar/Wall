import {Component} from '../../util';
import * as loginTemplate from './login.html!text';
import './login.css!';

@Component('wallLogin', {
    template: loginTemplate
})
class WallLogin implements ng.IComponentController {
    public user: string;
    public password: string;

    public login() {
        console.log(`Login ${this.user} with pass ${this.password}`)
    }
}