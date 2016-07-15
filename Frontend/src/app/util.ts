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

export function Service(name: string) {
    return function (target) {
        app.service(name, target);
    }
}

export function Filter(name: string) {
    return function (target) {
        app.filter(name, () => new target().convert);
    }
}