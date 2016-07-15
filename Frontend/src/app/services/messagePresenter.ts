import {Inject, Service, Filter} from '../util';
import {IMessagePresenter, MessageButton, IFilter} from '../interfaces/services';
import * as angular from 'angular';

@Inject('$mdDialog')
@Service('MessagePresenter')
export class MessagePresenter implements IMessagePresenter {
    constructor(private $mdDialog: angular.material.IDialogService) {
    }

    public showMessage(title: string, message: string, buttons?: MessageButton[]): ng.IPromise<MessageButton> {
        if (!buttons || !buttons.length) buttons = [MessageButton.OK];

        return this.$mdDialog.show({
            templateUrl: 'app/services/messagePresenter.html',
            controller: DialogController,
            controllerAs: '$ctrl',
            escapeToClose: false,
            locals: {
                title: title,
                message: message,
                buttons: buttons
            }
        });
    }
}

@Inject('$mdDialog', 'title', 'message', 'buttons')
class DialogController {
    constructor(
        private $mdDialog: angular.material.IDialogService, 
        public title: string, 
        public message: string, 
        public buttons: MessageButton[]) {
    }

    public closeDialog(button: MessageButton) {
        this.$mdDialog.hide(button);
    }
}

@Filter('messageButtonToText')
class MessageButtonToTextFilter implements IFilter<MessageButton, string> {
    public convert(input: MessageButton): string {
        switch (input) {
            case MessageButton.OK: 
                return 'OK';
            case MessageButton.Cancel: 
                return 'Cancel';
            case MessageButton.Yes: 
                return 'Yes';
            case MessageButton.No: 
                return 'No';
            default:
                return 'Undefined';
        }
    }
}
