import {Component, Inject} from '../../util';
import {ILoginService} from '../../interfaces/services'; 

@Component('wallToolbar', {
    templateUrl: 'app/components/toolbar/toolbar.html'
})
@Inject('LoginService', '$state')
class WallToolbar implements ng.IComponentController {
     constructor(private loginService: ILoginService,
                 private state: angular.ui.IStateService) {
     }

     public logout() {
         this.loginService.logout();
         this.state.go('login');
     }
}