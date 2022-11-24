import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookWishListComponent } from './bookwishlist/bookwishlist.component';
import { AddBookWishListComponent } from './add-book-wish-list/add-book-wish-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Book } from '../items/book';



@NgModule({
  declarations: [
    AddBookWishListComponent,
    BookWishListComponent

  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    BookWishListComponent,
    AddBookWishListComponent
  ]
})
export class WishlistModule { }
