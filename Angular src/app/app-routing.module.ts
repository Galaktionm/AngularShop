import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './authorization/login/login.component';
import { AccountComponent } from './authorization/account/account.component';
import { RegistrationComponent } from './authorization/registration/registration.component';
import { AuthGuard, LoginRegisterGuard } from './authorization/auth-guard.guard';

const routes: Routes = [
  {path: "", loadChildren: ()=>import ('./items/items.module').then(m=>m.ItemsModule), canActivate: [AuthGuard]},
  { path: "login", component: LoginComponent},
  { path: 'account', component: AccountComponent, canActivate: [AuthGuard]},
  { path: "register", component: RegistrationComponent},
  {path:"add", loadChildren: ()=>import ('./addingitem/addItemRouting').then(m=>m.AddItemRoutingModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
