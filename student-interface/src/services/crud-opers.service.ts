import { Injectable } from '@angular/core';
import {catchError, Observable, throwError} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Group} from '../models/group';

@Injectable({
  providedIn: 'root'
})
export class CrudOpersService {
  private readonly API_URL: string = "";

  constructor(private http: HttpClient) { }

  public getAllGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(this.API_URL)
      .pipe(
        catchError(error => {
          console.error('GET Error:', error);
          return throwError(() => new Error('Something went wrong'));
        })
      )
  }

  public getStudentGroups(id: number): Observable<Group[]> {
    return this.http.get<Group[]>(`${this.API_URL}/student/${id}/groups`)
      .pipe(
        catchError(error => {
          console.error('GET Error:', error);
          return throwError(() => new Error('Something went wrong'));
        })
      )
  }
}
