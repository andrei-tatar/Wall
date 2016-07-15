import {Service} from '../util';

@Service('LoginService')
export class LoginService implements Services.ILoginService {

    public isLoggedIn(): boolean {
        return false;
    }

    public login(user: string, password: string): ng.IPromise<any> {
        return undefined;
    }
}