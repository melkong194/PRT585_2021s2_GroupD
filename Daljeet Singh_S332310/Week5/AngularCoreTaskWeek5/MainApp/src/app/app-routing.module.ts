import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { productdetComponent } from './productdet/productdet.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';

const routes: Routes = [
  { path: '', component: productdetComponent, pathMatch: 'full' },
  { path: 'product/:id', component: ProductComponent },
  { path: 'add', component: ProductAddEditComponent },
  { path: 'product/edit/:id', component: ProductAddEditComponent },
  { path: '**', redirectTo: '/' }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
