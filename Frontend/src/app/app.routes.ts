import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { HomeComponent } from './features/home/home.component';
import { ProductListComponent } from './features/products/components/product-list/product-list.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'products', component: ProductListComponent },
  //   { path: 'online-users', component: OnlineUsersComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
