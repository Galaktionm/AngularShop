import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Laptop } from '../laptop';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-laptops',
  templateUrl: './laptops.component.html',
  styleUrls: ['./laptops.component.css']
})
export class LaptopsComponent implements OnInit {

  laptops!: Laptop[]

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    var url=environment.gateway+"api/Laptops/Starter"

    this.http.get<Laptop[]>(url).subscribe({
      next: (result)=>{
        this.laptops=result;
        console.log(result)
      },
      error: (error)=>{
        console.log(error);
      }
    })
  }

}
