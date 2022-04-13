import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';
import { environment } from 'src/environments/environment';
import { AppUser } from '../_models/AppUser';

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
