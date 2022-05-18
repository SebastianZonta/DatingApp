import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

 baseURL:string="https://localhost:7217/api/";

 private currentUserSource=new ReplaySubject<User>(1);
currentUser$=this.currentUserSource.asObservable();

  constructor(private http:HttpClient) { }

login(model:User){
 return this.http.post(this.baseURL+"Auth/login",model).pipe(
   map((response:User)=>
   {
     const user=response;
     if(user){
       localStorage.setItem('user',JSON.stringify(user));
       this.currentUserSource.next(user);
     }
   })
 );
}
register(model: User){
  return this.http.post(this.baseURL+'Auth/register',model).pipe(
    map( (user : User)=>{
      if(user){
        localStorage.setItem('user',JSON.stringify(user));
        this.currentUserSource.next(user);
      }
    })
  )
}
setCurrentUser(user : User){
  this.currentUserSource.next(user);
}
logout() : void{
  localStorage.removeItem('user');
  this.currentUserSource.next(null);
}


}
