import { HttpClient} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  users:any;
  constructor(private httpcontext:HttpClient){

  }
  ngOnInit(){
    this.getUsers();
  }
  getUsers(){
    this.httpcontext.get('https://localhost:7217/api/AppUser/getAll').subscribe(
      {
        next:response=> this.users=response,
        error: error=> console.log(error)
      })
  }

}
