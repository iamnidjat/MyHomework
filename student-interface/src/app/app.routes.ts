import { Routes } from '@angular/router';
import {AuthComponent} from '../components/auth/auth.component';
import {NotFoundComponent} from '../components/not-found/not-found.component';
import {RegistrationPageComponent} from '../components/registration-page/registration-page.component';
import {MainPageComponent} from '../components/main-page/main-page.component';

export const routes: Routes = [
  {
    path: "",
    redirectTo: "auth",
    pathMatch: "full",
  },
  {
    path: "auth",
    title: 'Authorization Page', //  the browser tab title
    component: AuthComponent
  },
  {
    path: "signup",
    title: 'Registration Page',
    component: RegistrationPageComponent
  },
  {
    path: "main-page", //
    title: 'Main Page',
    component: MainPageComponent
  },
  {
    path: "**", // better to place at the end
    component: NotFoundComponent,
  }
];
