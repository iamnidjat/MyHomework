import { Routes } from '@angular/router';
import {AuthComponent} from '../components/auth/auth.component';
import {NotFoundComponent} from '../components/not-found/not-found.component';

export const routes: Routes = [
  {
    path: "",
    redirectTo: "auth",
    pathMatch: "full",
  },
  {
    path: "auth",
    title: 'Auth Page', //  the browser tab title
    component: AuthComponent
  },
  {
    path: "**", // better to place at the end
    component: NotFoundComponent,
  }
];
