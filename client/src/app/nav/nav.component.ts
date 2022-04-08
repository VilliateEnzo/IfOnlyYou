import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { MenuOption } from '../_models/MenuOption';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  menuOptions: MenuOption[] =
    [
      new MenuOption("Matches", "/members", true),
      new MenuOption("Lists", "/lists", true),
      new MenuOption("Messages", "/messages", true),
    ];

  model: any = {};

  constructor(public _accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login(): void {
    this._accountService.loginUser(this.model).subscribe(
      result => {
        this.router.navigateByUrl('/members')
      },
      error => {
        this.toastr.error(error.error)
      })
  }

  logout(): void {
    this._accountService.logout()
    this.router.navigateByUrl('/')
  }
}
