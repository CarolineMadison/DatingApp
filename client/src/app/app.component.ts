import { Component, OnInit } from '@angular/core';
import { User } from './_models/User';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//implement a lifecycle event... OnInit Interface, which is a lifecycle hook
export class AppComponent implements OnInit {
  title = "Dating App";

  //happens as soon as our project is loaded, considered too early, so we implement an interface
  constructor(private accountService: AccountService) {}

  //this is our initalization code... make request to api
  //returns an Observable (stream of data), and we want to observe it as it comes back from our .NET application
  //Observables are lazy and won't happen, unless someone subscribes to it, which forces our request to go get the data
  //In subsribe method, we define what we want to do with that data
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
