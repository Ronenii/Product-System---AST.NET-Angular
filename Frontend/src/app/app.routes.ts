import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { ProductViewPageComponent } from './features/products/components/product-view-page/product-view-page.component';
import { ProductEditComponent } from './features/products/components/product-edit-page/product-edit-page.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'products', component: ProductViewPageComponent },
  { path: 'edit', component: ProductEditComponent },
  //   { path: 'online-users', component: OnlineUsersComponent },
  { path: '', redirectTo: '/products', pathMatch: 'full' },
];
