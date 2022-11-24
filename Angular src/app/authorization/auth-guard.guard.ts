import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './authservice';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService) {};
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isPermitted();
  }

  isPermitted(){
    if(this.authService.getToken!=null){
      return true;
    } 
    return false;
  }

  
}

export class LoginRegisterGuard implements CanActivate {

  constructor(private authService: AuthService) {};

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isRegisterPermitted();
  }

  isRegisterPermitted(){
    if(this.authService.getToken==null){
      return true;
    } 
    return false;
  }


}
