import { Routes } from '@angular/router';
import {AuthComponent} from '../components/auth/auth.component';
import {NotFoundComponent} from '../components/not-found/not-found.component';
import {RegistrationPageComponent} from '../components/registration-page/registration-page.component';
import {MainPageComponent} from '../components/main-page/main-page.component';
import {GradesComponent} from '../components/grades/grades.component';
import {HomeworkComponent} from '../components/homework/homework.component';
import {UnitsComponent} from '../components/units/units.component';

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
    path: "main-page/:id", //
    title: 'Main Page',
    component: MainPageComponent
  },
  {
    path: "group/:group-id",
    title: 'Group Page',
    component: MainPageComponent
  },
  {
    path: "grades/:id",
    title: 'Grades Page',
    component: GradesComponent
  },
  {
    path: "group/:group-id/homeworks", // homework separate, student-teacher logics
    title: 'Homeworks Page',
    component: HomeworkComponent
  },
  {
    path: "group/:group-id/units",
    title: 'Units Page',
    component: UnitsComponent
  },
  {
    path: "**", // better to place at the end
    component: NotFoundComponent,
  }
];
