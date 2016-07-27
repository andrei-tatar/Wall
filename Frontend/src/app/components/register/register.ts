import {Component, Inject} from '../../util';
import {ILoginService, IMessagePresenter} from '../../interfaces/services';
import './register.css!';

@Component('wallRegister', {
    templateUrl: 'app/components/register/register.html'
})
@Inject('LoginService', 'MessagePresenter', '$state')
class WallRegister implements ng.IComponentController {
    public user: string;
    public password: string;
    public confirmPassword: string;
    public userType: string;

    constructor(private loginService: ILoginService,
                private messagePresenter: IMessagePresenter,
                private state: angular.ui.IStateService) {
    }

    public register() {
        this.loginService
            .register(this.user, this.password)
            .then(_ => this.state.go('login'))
            .catch(err => this.registerFailed(err));
    }

    private registerFailed(err) {
        this.messagePresenter
            .showMessage('Error', err.data.message);
    }
}