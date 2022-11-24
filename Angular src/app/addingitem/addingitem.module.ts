import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddBookComponent } from './addbook/addbook.component';
import { AddItemRoutingModule } from './addItemRouting';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddBookComponent
  ],
  imports: [
    CommonModule,
    AddItemRoutingModule,
    ReactiveFormsModule
  ]
})
export class AddItemModule { }
