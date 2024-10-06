import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { HomeComponent } from './features/home/home.component';
import { ProductViewPageComponent } from './features/products/components/product-view-page/product-view-page.component';
import { ProductEditComponent } from './features/products/components/product-edit-page/product-edit-page.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'products', component: ProductViewPageComponent },
  { path: 'edit', component: ProductEditComponent },
  //   { path: 'online-users', component: OnlineUsersComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
