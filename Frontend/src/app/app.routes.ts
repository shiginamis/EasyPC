import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { SupportComponent } from './support/support.component';
import { HomeComponent } from './home/home.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home',pathMatch:'full'},
    { path: 'home',component: HomeComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'orders', component: OrdersComponent },
    { path: 'support', component: SupportComponent },
    { path: 'products', component: ProductsComponent },
    { path: 'nav-bar', component: NavBarComponent },
    { path: '**',redirectTo: '/home', pathMatch: 'full' },
];
