import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Login} from '../models/login';
import {catchError, Observable, throwError} from 'rxjs';
import {AuthResponseDto} from '../models/auth-response';
import {Register} from '../models/register';


@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private readonly API_URL: string = "https://localhost:7294/api/v1/Auth";

  constructor(private http: HttpClient) {}

  public login(credentials: Login): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.API_URL}/login`, credentials)
      .pipe(
        catchError(error => {
          console.error('POST Error:', error);
          return throwError(() => new Error('Failed to post data'));
        })
      );
  }

  public signup(credentials: Register): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.API_URL}/signup`, credentials)
      .pipe(
        catchError(error => {
          console.error('POST Error:', error);
          return throwError(() => new Error('Failed to post data'));
        })
      );
  }

  public getRandomUsername(): Observable<string> {
    return this.http.get<any>(`${this.API_URL}/random-username`)
    .pipe(
      catchError(error => {
        console.error('GET Error:', error);
        return throwError(() => new Error('Something went wrong'));
      })
    );
  }

  public isStudentProfileFrozen(username: string): Observable<boolean> {
    return this.http.get<any>(`${this.API_URL}/students/${username}/is-frozen`)
      .pipe(
        catchError(error => {
          console.error('GET Error:', error);
          return throwError(() => new Error('Something went wrong'));
        })
      );
  }
}
