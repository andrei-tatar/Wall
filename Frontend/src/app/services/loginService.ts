import {Service, Inject} from '../util';
import {ILoginService} from '../interfaces/services';

@Service('LoginService')
@Inject('$http', 'apiUri')
export class LoginService implements ILoginService {
    private _authTokenKey:string = "wall:AuthorizationToken";

    constructor(private http: ng.IHttpService,
                private apiUri: string) {
        if (localStorage) {
            var token: string = localStorage.getItem(this._authTokenKey);
            if (token && token.length > 0) {
                this.setToken(token);
            }
        }
    }

    public login(user: string, password: string): ng.IPromise<any> {
        return this.http
            .post(`${this.apiUri}api/login`, {
                user: user,
                password: password
            })
            .then(response => this.setToken(<string>response.data));
    }

    public logout() {
        delete this.http.defaults.headers.common.Authorization;
        if (localStorage) {
            localStorage.removeItem(this._authTokenKey);
        }
    }

    public register(user: string, password: string): ng.IPromise<any> {
        return this.http
            .post(`${this.apiUri}api/register`, {
                id: user,
                password: password
            });
    }

    private setToken(token: string) {
        this.http.defaults.headers.common.Authorization = token;
        if (localStorage) {
            localStorage.setItem(this._authTokenKey, token);
        }
    }
}