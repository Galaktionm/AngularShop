import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginRequest } from "./login/loginrequest";
import { LoginResult } from "./login/loginresult";
import { environment } from "src/environments/environment";




@Injectable({
    providedIn: "root"
})

export class AuthService{

    constructor(private http: HttpClient){}

    login(request: LoginRequest): Observable<LoginResult>{
        var url=environment.userAPI + "api/Authorization/Login"
        var result=this.http.post<LoginResult>(url, request);
        return result;
    }

    getToken() : string{
        var token=sessionStorage.getItem("token");
        return token!;
    }




}