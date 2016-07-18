import { app } from './app';

export function Component(name: string, options: ng.IComponentOptions) {
    return target => {
        options.controller = target;
        app.component(name, options);
    };
}

export function Inject(...what: string[]) {
    return target => {
        target.$inject = what;
    };
}

export function Service(name: string) {
    return target => {
        app.service(name, target);
    };
}

export function Filter(name: string) {
    return target => {
        app.filter(name, () => new target().convert);
    };
}

export function Directive(name: string) {
    return target => {
        app.directive(name, () => new target());
    };
}