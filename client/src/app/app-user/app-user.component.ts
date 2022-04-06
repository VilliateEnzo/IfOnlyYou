import { Component, OnInit } from '@angular/core';
import { AppUserService } from './app-user.service';
import { AppUser } from './AppUser';

@Component({
  selector: 'app-user',
  templateUrl: './app-user.component.html',
  styleUrls: ['./app-user.component.css']
})
export class AppUserComponent implements OnInit {

  constructor(private _userService: AppUserService) { }

  ngOnInit(): void {
    this.getAllUsers()
  }

  users: AppUser[]

  getAllUsers(): void {
    this._userService.getAllUsers().subscribe(
      result => {
        this.users = result;
      },
      error => {
        console.log(error)
      })
  }

}
