import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorizationModule } from './authorization/authorization.module';
import { AuthInterceptor } from './authorization/authInterceptor';
import { CoreModule } from './core/core.module';
import { AddItemModule } from './addingitem/addingitem.module';
import { ItemsModule } from './items/items.module';
import { WishlistModule } from './wishlist/wishlist.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthorizationModule,
    ItemsModule,
    AddItemModule,
    CoreModule,
    WishlistModule

  ],
  providers: [{ provide: HTTP_INTERCEPTORS, 
    useClass: AuthInterceptor, 
    multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
