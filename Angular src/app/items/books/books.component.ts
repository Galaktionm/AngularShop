import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from '../book';



@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books! : Book[];


  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.refreshData();
    //setInterval(()=>this.refreshData, 30000)
  }

  refreshData():void{
    var url=environment.gateway+"api/Books/All"
    this.http.get<Book[]>(url).subscribe({
      next: (result)=>{
        this.books=result;
      },
      error: (error)=>{
        console.log(error);
      }
    })
  }



}
