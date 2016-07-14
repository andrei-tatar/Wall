import { app } from './app';

function Controller(name: string, ...inject: string[]) {
    return function (target) {
        inject.push(target);
        app.controller(name, inject);
    }
}

export {Controller};