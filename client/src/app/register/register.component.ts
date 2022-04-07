import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() calcelRegister = new EventEmitter();

  model: any = {};

  constructor(private _accountService: AccountService) { }

  ngOnInit(): void {
  }

  register() {
    this._accountService.register(this.model).subscribe(
      result => {
        console.log(result)
        this.cancel();
      },
      error => {
        console.log(error)
      })
  }

  cancel() {
    this.calcelRegister.emit(false);
  }
}
