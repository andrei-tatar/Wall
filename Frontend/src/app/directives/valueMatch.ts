import {Directive} from '../util';

@Directive('valueMatch')
class ValueMatchDirective implements ng.IDirective {
    public restrict = 'A';
    public require = 'ngModel';

    public link(scope: ng.IScope, element, attr: ng.IAttributes, ngModel: ng.INgModelController) {
        var desiredValue;
        scope.$watch(attr['valueMatch'], newValue => {
            desiredValue = newValue;
            ngModel.$validate();
        });
        ngModel.$validators['valueMatch'] = (modelValue, viewValue) => (modelValue || viewValue) === desiredValue;
    }
}
