import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { ProductViewPageComponent } from './features/products/components/product-view-page/product-view-page.component';
import { ProductEditComponent } from './features/products/components/product-edit-page/product-edit-page.component';
import { authGuard } from './core/auth/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'products',
    component: ProductViewPageComponent,
    canActivate: [authGuard],
  },
  { path: 'edit', component: ProductEditComponent, canActivate: [authGuard] },
  //   { path: 'online-users', component: OnlineUsersComponent },
  { path: '', redirectTo: '/products', pathMatch: 'full' },
];
