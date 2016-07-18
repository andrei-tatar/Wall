import {Component, Inject} from '../../util';
import {ILoginService} from '../../interfaces/services';

@Component('wallHome', {
    templateUrl: 'app/components/home/home.html'
})
@Inject('LoginService', '$state')
class HomeComponent implements ng.IComponentController {
    constructor(private loginService: ILoginService,
                private state: angular.ui.IStateService) {
    }

    public $onInit() {
        if (!this.loginService.isLoggedIn())
            this.state.go('login');
    }
}