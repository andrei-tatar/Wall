import {Component, Inject} from '../../util';
import './login.css!';

@Component('wallLogin', {
    templateUrl: 'app/components/login/login.html'
})
@Inject('LoginService', 'MessagePresenter')
class WallLogin implements ng.IComponentController {
    public user: string;
    public password: string;

    constructor(private loginService: Services.ILoginService,
                private messagePresenter: Services.IMessagePresenter) {
        
    }

    public login() {
        this.loginService
            .login(this.user, this.password)

        this.messagePresenter.showMessage('Hello', 'You want to login?');
        //console.log(`Login ${this.user} with pass ${this.password}`)
    }
}