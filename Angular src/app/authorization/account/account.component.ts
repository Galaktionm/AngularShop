import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as signalR from "@microsoft/signalr";
import { Subject } from 'rxjs';
import { User } from '../user';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  user!:User
 private hubConnection!: signalR.HubConnection;
 public result?: string

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getUserData();
    this.startConnection();
    this.addDataListeners();
  }

  getUserData(){
    var url=environment.userAPI+"api/Account/"+sessionStorage.getItem("userId")

    this.http.get<User>(url).subscribe({
      next: (result)=>[
        console.log(result),
        this.user=result
      ],
      error: (error)=>{
        console.log(error)
      }
    })
  }

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Information)
    .withUrl(environment.userAPI + 'api/WishListHub', { withCredentials: 
   false })
    .build();
    console.log("Starting connection...");
    this.hubConnection
    .start()
    .then(() => console.log("Connection started."))
    .catch((err : any) => console.log(err));
    this.updateData();
    }

    public addDataListeners() {
      this.hubConnection.on('Update', (msg) => {
      console.log("Update issued by server for the following reason: " + msg);
      this.updateData();
      });
    }
      
    public updateData() {
      console.log("Fetching data...");
      this.http.get<string>(environment.userAPI + 'api/WishList/Update').subscribe({
        next: (result)=>{
          this.result=result;
          console.log(result)
        },
        error: (error)=>{
          console.log(error);
        }
      } );
      
  };
    


}
