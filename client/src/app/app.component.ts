import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';

  ngOnInit() { }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));

  }
}
