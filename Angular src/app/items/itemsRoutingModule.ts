import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { Routes } from "@angular/router";
import { AddBookWishListComponent } from "../wishlist/add-book-wish-list/add-book-wish-list.component";
import { BookWishListComponent } from "../wishlist/bookwishlist/bookwishlist.component";
import { BooksComponent } from "./books/books.component";
import { LaptopsComponent } from "./laptops/laptops.component";



const routes: Routes = [
  { path: 'books', component: BooksComponent},
  { path: "books/add/wishlist", component: AddBookWishListComponent},
  { path: "books/wishlist", component: BookWishListComponent},
  { path: "laptops", component: LaptopsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemRoutingModule { }

