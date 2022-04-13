import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';


@Injectable({
  providedIn: 'root'
})
export class MemberService {
  constructor(private http: HttpClient) {
  }

  apiUrl: string = environment.apiUrl;

  getMembers() {
    return this.http.get<Member[]>(this.apiUrl + 'users');
  }

  getMemberByUsername(username: string) {
    return this.http.get<Member>(this.apiUrl + 'users/getMember/' + username);
  }
}
