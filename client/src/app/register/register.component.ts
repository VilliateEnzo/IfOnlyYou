import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() calcelRegister = new EventEmitter();

  model: any = {};

  constructor(private _accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register() {
    this._accountService.register(this.model).subscribe(
      result => {
        this.router.navigateByUrl('/members')
      })
  }

  cancel() {
    this.calcelRegister.emit(false);
  }
}
