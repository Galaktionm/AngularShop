import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../authservice';

import { LoginRequest } from './loginrequest';
import { LoginResult } from './loginresult';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!:  FormGroup;

  loginResult?: LoginResult;

  constructor(private service: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm=new FormGroup({
      email: new FormControl(''),
      password: new FormControl('')      
  });
  }

  sendRequest() {
    var email=this.loginForm.controls["email"].value;
    var password=this.loginForm.controls["password"].value;

    var loginRequest= new LoginRequest(email, password);
    

    this.service.login(loginRequest).subscribe({
      next: (result)=>{
        console.log(result);
        this.loginResult=result;
        sessionStorage.setItem("token", result.token);
        sessionStorage.setItem("userId", result.id)
        this.router.navigate(["books"]);
      },

      error: (error)=>{
        console.log(error);
        if (error.status == 401) {
          this.loginResult = error.error;
        }
      }
    })


  }

}
