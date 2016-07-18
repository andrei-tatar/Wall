import {Component, Inject} from '../../util';
import {ILoginService, IMessagePresenter, MessageButton} from '../../interfaces/services';
import './login.css!';

@Component('wallLogin', {
    templateUrl: 'app/components/login/login.html'
})
@Inject('LoginService', 'MessagePresenter', '$state')
class WallLogin implements ng.IComponentController {
    public user: string;
    public password: string;

    constructor(private loginService: ILoginService,
                private messagePresenter: IMessagePresenter,
                private state: angular.ui.IStateService) {
    }

    public login() {
        this.loginService
            .login(this.user, this.password)
            .catch(err => this.loginFailed())
            .then(_ => this.state.go('home'));
    }

    private loginFailed() {
        this.messagePresenter
            .showMessage('Error', 'Could not perform login.', [MessageButton.OK]);
    }

    public register() {
        this.state.go('register');
    }
}