import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import * as signalR from "@aspnet/signalr";
//import { MessageService } from 'primeng/api/messageservice';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  private hubConnection: signalR.HubConnection;

  constructor(private messageService: MessageService) {}
  addSingle() {
      this.messageService.add({severity: 'success', summary: 'Service Message', detail: 'Via MessageService'});
  }

  ngOnInit(): void {
    this.startConnection();
    this.hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
      this.messageService.add({ severity: type, summary: payload });
    });
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('/notify')
                            .build();

    this.hubConnection
      .start()
      .then(() =>  this.messageService.add({ severity: 'success' , summary: 'Connection started' }))
      .catch(err => console.log('Error while starting connection: ' + err));
  }
}
