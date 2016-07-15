import {Inject, Service} from '../util';
import * as angular from 'angular';

@Inject('$mdDialog')
@Service('MessagePresenter')
export class MessagePresenter implements Services.IMessagePresenter {
    constructor(private $mdDialog: angular.material.IDialogService) {

    }

    public showMessage(title: string, message: string): ng.IPromise<Services.MessageResult> {
        var dialog = this.$mdDialog
            .alert()
            .parent(angular.element(document.querySelector('#popupContainer')))
            .clickOutsideToClose(true)
            .title('This is an alert title')
            .textContent('You can specify some description text in here.')
            .ariaLabel('Alert Dialog Demo')
            .ok('Got it!');
            //.targetEvent(ev)

        return this.$mdDialog.show(dialog);
    }
}