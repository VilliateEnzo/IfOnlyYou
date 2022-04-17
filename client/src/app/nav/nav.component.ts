import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { MenuOption } from '../_models/MenuOption';
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
      new MenuOption("Matches", "/member", true),
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
        this.router.navigateByUrl('/member')
      })
  }

  logout(): void {
    this._accountService.logout()
    this.router.navigateByUrl('/')
  }
}
