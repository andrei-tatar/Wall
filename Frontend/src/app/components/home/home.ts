import {Component, Inject} from '../../util';
import {ILoginService} from '../../interfaces/services';

@Component('wallHome', {
    templateUrl: 'app/components/home/home.html'
})
@Inject('LoginService', '$state', '$http', 'apiUri')
class HomeComponent implements ng.IComponentController {
    public homeMessage: string;

    constructor(private loginService: ILoginService,
                private state: angular.ui.IStateService,
                private http: angular.IHttpService,
                private apiUri: string) {
    }

    public $onInit() {
        this.http
            .get(`${this.apiUri}api/home`)
            .then(result => this.homeMessage = <string>result.data)
            .catch(_ => this.state.go('login'));
    }
}