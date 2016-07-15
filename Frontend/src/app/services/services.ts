declare module Services {
    interface ILoginService {
        isLoggedIn(): boolean;
        login(user: string, password: string): ng.IPromise<any>;
    }

    interface IMessagePresenter {
        showMessage(title: string, message: string): ng.IPromise<MessageResult>;
    }

    enum MessageResult {

    }
}

import './loginService';
import './messagePresenter';