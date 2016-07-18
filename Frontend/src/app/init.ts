import {ILoginService} from './interfaces/services';
import {app} from './app';

app.run(init);

init.$inject = ['$state', 'LoginService']
function init(
    state: ng.ui.IStateService,
    loginService: ILoginService) {

    if (!loginService.isLoggedIn())
        state.go('login');
    else
        state.go('home');
}
