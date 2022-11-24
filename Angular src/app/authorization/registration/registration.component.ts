import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registrationForm!: FormGroup

  constructor(private http:HttpClient) { }

  ngOnInit(): void {

    this.registrationForm=new FormGroup({
      username: new FormControl(""),
      email: new FormControl(""),
      password: new FormControl("")
    })
  }

  registerUser(){
    var username=this.registrationForm.controls["username"].value;
    var email=this.registrationForm.controls["email"].value;
    var password=this.registrationForm.controls["password"].value;

    var url=environment.userAPI+"api/Authorization/Register"

    this.http.post(url, (usernameValue:string, emailValue:string, passwordValue:string)=>{
      usernameValue=username,
      emailValue=email,
      passwordValue=password
    })
    .subscribe({
      next: (result)=>{
        console.log(result)
      },
      error: (error)=>{
        console.log(error)
      }
    })

  }

}
