import {Component, inject} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {Login} from '../../models/login';
import {Register} from '../../models/register';
import {catchError, Observable, throwError} from 'rxjs';

@Component({
  selector: 'app-auth',
  imports: [],
  templateUrl: './auth.component.html',
  standalone: true,
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  private authService: AuthService = inject(AuthService);

  constructor() {}

  public login(credentials: Login) {
    this.authService.login(credentials).subscribe({
      next: (response) => console.log(response),
      error: (err) => console.error(err)
    });
  }

  public signup(credentials: Register) {
    this.authService.signup(credentials).subscribe({
      next: (response) => console.log(response),
      error: (err) => console.error(err)
    });
  }

  public getRandomUsername() {
    this.authService.getRandomUsername().subscribe({
      next: (response) => console.log(response),
      error: (err) => console.error(err)
    });
  }
}
