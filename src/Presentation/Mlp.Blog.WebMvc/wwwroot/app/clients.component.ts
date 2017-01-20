import { Component } from "@angular/core"

@Component({
    selector: "clients",
    template: `
                <h2>{{title}}</h2>
                <ul><li *ngFor="let client of clients">{{ client }}</li></ul>
              `
})

export class ClientsComponent {
    title = "Clients";
    clients = ["1","2","3"]
    
}