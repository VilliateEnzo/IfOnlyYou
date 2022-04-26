import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';
import { environment } from 'src/environments/environment';
import { AppUser } from '../_models/AppUser';
import { Photo } from '../_models/photo';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class PhotoService extends AppService {

  constructor(private Http: HttpClient) {
    super();
  }

  apiUrl: string = environment.apiUrl;

  setMainPhoto(photoId: number): Observable<any> {
    return this.Http.put<Photo>(this.apiUrl + `photo/set-main-photo/` + photoId, {});
  }

  deletePhoto(photoId: number): Observable<any> {
    return this.Http.delete<Member>(this.apiUrl + `photo/` + photoId);
  }
}
