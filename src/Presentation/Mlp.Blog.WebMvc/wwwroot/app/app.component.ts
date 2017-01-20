import { Component } from '@angular/core';
import { ClientsComponent } from './clients.component'

@Component({
    selector: 'my-app',
    template: '<h1>My First Angular 2 App</h1><clients></clients>',
    entryComponents: [ClientsComponent]
})
export class AppComponent { }