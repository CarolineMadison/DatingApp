import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//implement a lifecycle event... OnInit Interface, which is a lifecycle hook
export class AppComponent implements OnInit {
  title = "Dating App";
  users: any; //setting any as the type of users 

  //happens as soon as our project is loaded, considered too early, so we implement an interface
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log("request has completed"),
    })
  }
}
