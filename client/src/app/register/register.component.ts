import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model:any={};
  @Output() cancelRegister=new EventEmitter<boolean>();
  constructor(private service:AccountService) { }

  ngOnInit(): void {
  }
  register(){
    this.service.register(this.model).subscribe({
      next:response=>
      {
        console.log(response);
        this.cancel();
      },
      error:error=>console.log(error)
    });
  }
  cancel(){
    this.cancelRegister.emit(false);
  }

}
