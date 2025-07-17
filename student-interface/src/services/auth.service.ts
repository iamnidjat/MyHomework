import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Login} from '../models/login';
import {Observable} from 'rxjs';
import {AuthResponseDto} from '../models/auth-response';


@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private readonly API_URL: string = "";

  constructor(private http: HttpClient) { }

  login(credentials: Login): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.API_URL}/auth/login`, credentials);
  }
}
