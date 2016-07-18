import {Component} from '../../util';
//import './login.css!';

@Component('wallRegister', {
    templateUrl: 'app/components/register/register.html'
})
class WallRegister implements ng.IComponentController {
    public user: string;
    public password: string;
    public confirmPassword: string;
    public userType: string;
     
}