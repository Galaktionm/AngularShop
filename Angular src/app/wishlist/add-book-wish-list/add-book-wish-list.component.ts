import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { BookWishList } from '../bookwishlist';

@Component({
  selector: 'app-add-book-wish-list',
  templateUrl: './add-book-wish-list.component.html',
  styleUrls: ['./add-book-wish-list.component.css']
})
export class AddBookWishListComponent implements OnInit {


  bookWishForm!:FormGroup


  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.bookWishForm=new FormGroup({
      lowPrice: new FormControl(''),
      highPrice: new FormControl(''),
      title: new FormControl(''),
      author: new FormControl(''),
      genre: new FormControl('')
    })
  }

  postBookWish(){

    var lowPrice=this.bookWishForm.controls["lowPrice"].value;
    var highPrice=this.bookWishForm.controls["highPrice"].value;
    var title=this.bookWishForm.controls["title"].value;
    var author=this.bookWishForm.controls["author"].value;
    var genre=this.bookWishForm.controls["genre"].value;

    var url=environment.gateway+"api/Books/Add/Wishlist"

    var bookWish=new BookWishList(sessionStorage.getItem("userId")!, lowPrice, highPrice, title, author, genre);

    this.http.post(url, bookWish).subscribe({
      next: (result)=>{
        console.log(result);
      },
      error: (error)=>{
        console.log(error);
      }
    })



  }

}
