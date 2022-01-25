import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getAllJSDocTagsOfKind } from 'typescript';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) {

  }
  public getAllTask(): Observable<any> {
    return this.http.get(environment.apiUrl + '/Task/get-all-tasks');
  }
}
