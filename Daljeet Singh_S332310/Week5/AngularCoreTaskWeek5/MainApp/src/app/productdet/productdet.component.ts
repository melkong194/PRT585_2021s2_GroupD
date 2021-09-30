import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Product } from 'Models/Product';

@Component({
  selector: 'app-productdet',
  templateUrl: './productdet.component.html',
  styleUrls: ['./productdet.component.scss']
})
export class productdetComponent implements OnInit {

  Products$!: Observable<Product[]>;

  constructor(private Productservice: ProductService) {
  }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.Products$ = this.Productservice.getProducts();
  }

  delete(Id: number) {
    const ans = confirm('Do you want to delete blog post with id: ' + Id);
    if (ans) {
      this.Productservice.deleteProduct(Id).subscribe((data: any) => {
        this.loadProducts();
      });
    }
  }

}
