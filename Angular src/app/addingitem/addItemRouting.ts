import { NgModule } from "@angular/core";
import { AddBookComponent } from "./addbook/addbook.component";
import { RouterModule } from "@angular/router";
import { Routes } from "@angular/router";


const routes: Routes = [{ path: 'book', component: AddBookComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddItemRoutingModule { }