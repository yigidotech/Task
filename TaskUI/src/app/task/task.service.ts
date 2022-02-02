import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getAllJSDocTagsOfKind } from 'typescript';
import { environment } from '../../environments/environment';
import { TaskModel } from '../models/task.model';
@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) {

  }
  public getAllTask(): Observable<any> {
    return this.http.get(environment.apiUrl + '/Task/get-all-tasks');
  }

  public getAllTasksByIsCompleted(isCompleted: boolean): Observable<any> {
    return this.http.get(environment.apiUrl + '/Task/get-all-tasks-by-is-completed?isCompleted=' + isCompleted);
  }

  public updateTask(id: number, task: TaskModel): Observable<any> {
    return this.http.put(environment.apiUrl + '/Task/update-task?id=' + id, task);
  }

  public deleteTask(id: number): Observable<any> {
    return this.http.delete(environment.apiUrl + '/Task/delete-task?id=' + id);
  }

  public createdTask(task: TaskModel): Observable<any> {
    return this.http.post(environment.apiUrl + '/Task/create-task', task);
  }

  public changeTaskComplete(task: TaskModel): Observable<any> {
    return this.http.put(environment.apiUrl + '/Task/change-task-complete', task);
  }
}
