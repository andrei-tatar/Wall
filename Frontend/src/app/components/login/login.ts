import {Component} from '../../util';
import './login.css!';

@Component('wallLogin', {
    templateUrl: 'app/components/login/login.html'
})
class WallLogin implements ng.IComponentController {
    public user: string;
    public password: string;

    public login() {
        console.log(`Login ${this.user} with pass ${this.password}`)
    }
}