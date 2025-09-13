import {Component, inject} from '@angular/core';
import {Register} from '../../models/register';
import {AuthService} from '../../services/auth.service';
import {Router, RouterLink} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-registration-page',
  imports: [
    FormsModule,
    RouterLink,
    NgIf
  ],
  standalone: true,
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {
  private authService: AuthService = inject(AuthService);

  public credentials: Register = {
    username: '',
    password: '',
    confirmPassword: '',
    email: '',
    birthdate: '',
  };

  constructor(private router: Router) {}

  public signup() {
    const birthdate = new Date(this.credentials.birthdate);
    const now = new Date();
    const minDate = new Date();
    minDate.setFullYear(now.getFullYear() - 14);

    if (birthdate > minDate) {
      alert("You must be at least 14 years old");
      return;
    }

    if (this.credentials.password !== this.credentials.confirmPassword) {
      alert("Passwords don't match");
      return;
    }

    this.authService.signup(this.credentials).subscribe({
      next: (response) => {
        console.log(response);
        localStorage.setItem('student-data', JSON.stringify(response));
        this.router.navigate(['/main-page', response.userId]);
      },
      error: (err) => console.error(err)
    });
  }

  public getRandomUsername() {
    this.authService.getRandomUsername().subscribe({
      next: (response) => {
        console.log(response);
        this.credentials.username = response;
      },
      error: (err) => console.error(err)
    });
  }
}
