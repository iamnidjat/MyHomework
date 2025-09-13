import {Component, inject} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {Login} from '../../models/login';
import {Register} from '../../models/register';
import {catchError, Observable, throwError} from 'rxjs';
import {FormsModule} from '@angular/forms';
import {Router, RouterLink} from '@angular/router';

@Component({
  selector: 'app-auth',
  imports: [FormsModule, RouterLink],
  standalone: true,
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  private authService: AuthService = inject(AuthService);

  public credentials: Login = {
    username: '',
    password: ''
  };

  constructor(private router: Router) {}

  public login() {
    if (!this.credentials.username || !this.credentials.password) {
      alert("Username and password are required");
      return;
    }

    this.authService.login(this.credentials).subscribe({
      next: (response) => {
        console.log(response);
        localStorage.setItem('student-data', JSON.stringify(response));
        this.router.navigate(['/main-page',response.userId]);
      },
      error: (err) => {
        console.error(err);
        alert("Incorrect credentials");
      }
    });
  }
}
