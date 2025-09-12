import {Component, inject} from '@angular/core';
import {Register} from '../../models/register';
import {AuthService} from '../../services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-registration-page',
  imports: [],
  standalone: true,
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css'
})
export class RegistrationPageComponent {
  private authService: AuthService = inject(AuthService);

  public credentials: Register = {
    username: '',
    password: ''
  };

  constructor(private router: Router) {}

  public signup(credentials: Register) {
    this.authService.signup(credentials).subscribe({
      next: (response) => {
        console.log(response);
        this.router.navigate(['/main-page']);
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
