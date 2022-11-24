import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from 'src/app/items/book';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { __asyncValues } from 'tslib';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './addbook.component.html',
  styleUrls: ['./addbook.component.css']
})
export class AddBookComponent implements OnInit {

  bookForm!: FormGroup
  starterBooks?: Book[]

  constructor(private http: HttpClient, private router:Router) { }

  ngOnInit(): void{

    this.bookForm=new FormGroup({
      price: new FormControl(''),
      available: new FormControl(''),
      author: new FormControl(''),
      title: new FormControl(''),
      genre: new FormControl(''),  
  });
  }

addBook(){

  var title=this.bookForm.controls["title"].value;
  var author=this.bookForm.controls["author"].value;
  var genre=this.bookForm.controls["genre"].value;
  var price=this.bookForm.controls["price"].value;
  var available=this.bookForm.controls["available"].value;

  var book=new Book(title, author, genre, price);
  book.available=available;

  var url="https://localhost:7050/api/Books/Add/"+sessionStorage.getItem("userId");

  this.http.post(url, book).subscribe({
    next: (result)=>{
      console.log(result)
      this.router.navigate(["books"]);
    },
    error: (error)=>{
      console.log(error);
    }
  });

}

}