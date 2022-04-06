import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';

@Injectable({
    providedIn: 'root'
})
export class LayoutService extends AppService {

    constructor(private Http: HttpClient) {
        super();
    }

    getExperiencia(): Observable<any[]> {
        return this.Http.get<string[]>("/get_experiencia/");
    }
}
