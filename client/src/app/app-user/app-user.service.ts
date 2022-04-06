import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';
import { AppUser } from './AppUser';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AppUserService extends AppService {

    constructor(private Http: HttpClient) {
        super();
    }

    apiUrl: string = environment.apiUrl;

    getAllUsers(): Observable<AppUser[]> {
        return this.Http.get<AppUser[]>(this.apiUrl + "users/");
    }
}
