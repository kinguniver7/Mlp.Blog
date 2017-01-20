import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ClientsComponent } from './clients.component'

@NgModule({
    imports: [BrowserModule],
    declarations: [AppComponent, ClientsComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }