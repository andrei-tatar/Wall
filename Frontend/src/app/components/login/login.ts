import {Component, Inject} from '../../util';
import {ILoginService, IMessagePresenter, MessageButton} from '../../interfaces/services';
import './login.css!';

@Component('wallLogin', {
    templateUrl: 'app/components/login/login.html'
})
@Inject('LoginService', 'MessagePresenter')
class WallLogin implements ng.IComponentController {
    public user: string;
    public password: string;

    constructor(private loginService: ILoginService,
                private messagePresenter: IMessagePresenter) {
    }

    public login() {
        this.loginService
            .login(this.user, this.password)

        this.messagePresenter
            .showMessage('Hello', 'You want to login?', [MessageButton.Yes, MessageButton.No]);
        //console.log(`Login ${this.user} with pass ${this.password}`)
    }
}