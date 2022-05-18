import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any={};
  loggedIn:boolean=false;
  constructor(public service:AccountService,
              private router: Router,
              private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  login(){
    this.service.login(this.model).subscribe({
        next:
        response=>
        {
          this.router.navigateByUrl('/members');
          console.log(response);
        },
        error: error=>
        {
          console.log(error);
          this.toastr.error(error.error);
        }
      })
  }
  logout(){
    this.service.logout();
    this.router.navigateByUrl('');
  }
}
