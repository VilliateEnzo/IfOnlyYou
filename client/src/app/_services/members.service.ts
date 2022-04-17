import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';


@Injectable({
  providedIn: 'root'
})
export class MemberService {
  constructor(private http: HttpClient) {
  }

  apiUrl: string = environment.apiUrl;
  members: Member[] = [];

  getMembers() {
    if (this.members.length > 0) return of(this.members)

    return this.http.get<Member[]>(this.apiUrl + 'users').pipe(
      map(members => {
        this.members = members;
        return members;
      })
    );
  }

  getMemberByUsername(username: string) {
    const member = this.members.find(member => member.userName === username);
    if (member !== undefined) return of(member)

    return this.http.get<Member>(this.apiUrl + 'users/getMember/' + username);
  }

  updateMember(member: Member) {
    return this.http.put<Member>(this.apiUrl + 'users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    );
  }
}
