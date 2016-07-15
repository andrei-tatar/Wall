export interface ILoginService {
    isLoggedIn(): boolean;
    login(user: string, password: string): ng.IPromise<any>;
}

export interface IMessagePresenter {
    showMessage(title: string, message: string, buttons?: MessageButton[]): ng.IPromise<MessageButton>;
}

export interface IFilter<From, To> {
    convert(input: From, ...params: any[]): To;
}

export enum MessageButton {
    OK, Cancel, Yes, No
}