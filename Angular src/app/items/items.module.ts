import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books/books.component';
import { ItemRoutingModule } from './itemsRoutingModule';

import { LaptopsComponent } from './laptops/laptops.component';
import { AppRoutingModule } from '../app-routing.module';




@NgModule({
  declarations: [
    BooksComponent,
    LaptopsComponent,
  ],
  imports: [
    CommonModule,
    ItemRoutingModule
 
  ], 
  exports: [
    BooksComponent,
    LaptopsComponent
  ]
})
export class ItemsModule { }
