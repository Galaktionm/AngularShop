
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/items/book';

@Component({
  selector: 'app-bookwishlist',
  templateUrl: './bookwishlist.component.html',
  styleUrls: ['./bookwishlist.component.css']
})
export class BookWishListComponent implements OnInit {

  wishListBooks!:Book[]

  constructor(private http:HttpClient) { }

  ngOnInit(): void {

    var url="http://localhost:8113/api/Books/WishList/"+sessionStorage.getItem("userId")

    this.http.get<Book[]>(url).subscribe({
      next: (result)=>[
        console.log(result),
        this.wishListBooks=result
      ],
      error: (error)=>{
        console.log(error)
      }
    })
  }

}
