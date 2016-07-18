import {Service, Inject} from '../util';
import {ILoginService} from '../interfaces/services';

@Service('LoginService')
@Inject('$http', 'apiUri')
export class LoginService implements ILoginService {

    constructor(private http: ng.IHttpService,
                private apiUri: string) {
    }

    public isLoggedIn(): boolean {
        return false;
    }

    public login(user: string, password: string): ng.IPromise<any> {
        return this.http.post(this.apiUri + 'api/login', {
            user: user,
            password: password
        });
    }
}