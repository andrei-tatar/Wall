import { app } from './app';

export function Component(name: string, options: ng.IComponentOptions) {
    return function (target) {
        options.controller = target;
        app.component(name, options);
    };
}

export function Inject(...what: string[]) {
    return function (target) {
        target.$inject = what;
    };
}