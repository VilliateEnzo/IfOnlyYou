import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { MenuOption } from '../_models/MenuOption';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  a = new MenuOption("Matches", "", false, false, "")

  menuOptions: MenuOption[] =
    [
      new MenuOption("Matches", "", false, false, ""),
      new MenuOption("Lists", "", false, false, ""),
      new MenuOption("Messages", "", false, false, ""),
    ];

  model: any = {};

  constructor(public _accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(): void {
    this._accountService.loginUser(this.model).subscribe(
      result => {
        console.log(result)
      },
      error => {
        console.log(error)
      })
  }

  logout(): void {
    this._accountService.logout()
  }
}
