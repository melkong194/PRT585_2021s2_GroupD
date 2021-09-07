import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Product } from 'Models/Product';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {


  Product$!: Observable<Product>;
  Id!: number;

  constructor(private ProductService: ProductService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.Id = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct() {
    this.Product$ = this.ProductService.getProduct(this.Id);
  }
}
