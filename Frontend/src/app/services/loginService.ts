import {Service} from '../util';
import {ILoginService} from '../interfaces/services';

@Service('LoginService')
export class LoginService implements ILoginService {

    public isLoggedIn(): boolean {
        return false;
    }

    public login(user: string, password: string): ng.IPromise<any> {
        return undefined;
    }
}