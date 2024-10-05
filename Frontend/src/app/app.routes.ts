import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'home', HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'online-users', component: OnlineUsersComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
