import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { ProductService } from './services/product.service';
import { productdetComponent } from './productdet/productdet.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ProductAddEditComponent,
    productdetComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
