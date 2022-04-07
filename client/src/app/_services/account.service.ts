import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppService } from '../app.service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';
import { ReplaySubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AccountService extends AppService {

    private currentUserSource = new ReplaySubject<User>(1);
    currentUser$ = this.currentUserSource.asObservable()

    constructor(private Http: HttpClient) {
        super();
    }

    apiUrl: string = environment.apiUrl;

    loginUser(model: any) {
        return this.Http.post(this.apiUrl + "account/login", model).pipe(
            map((response: User) => {
                const user = response;
                if (user) {
                    localStorage.setItem('user', JSON.stringify(user))
                    this.currentUserSource.next(user)
                }
            })
        );
    }

    register(model: any) {
        return this.Http.post(this.apiUrl + "account/register", model).pipe(
            map((response: User) => {
                const user = response;
                if (user) {
                    localStorage.setItem('user', JSON.stringify(user))
                    this.currentUserSource.next(user)
                }
            })
        );
    }

    setCurrentUser(user: User) {
        this.currentUserSource.next(user)
    }

    logout() {
        localStorage.removeItem('user');
        this.currentUserSource.next(null)
    }
}