import {Component, inject} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {Login} from '../../models/login';

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

  login() {

  }

}
