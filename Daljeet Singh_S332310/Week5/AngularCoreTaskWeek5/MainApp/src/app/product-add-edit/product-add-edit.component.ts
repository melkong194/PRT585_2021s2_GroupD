import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from 'Models/Product';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.scss']
})
export class ProductAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formTitle: string;
  formBody: string;
  Id!: number;
  errorMessage: any;
  existingProduct!: Product;

  constructor(private ProductService: ProductService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formTitle = 'title';
    this.formBody = 'body';
    if (this.avRoute.snapshot.params[idParam]) {
      this.Id = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        Id: 0,
        title: ['', [Validators.required]],
        body: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {

    if (this.Id > 0) {
      this.actionType = 'Edit';
      this.ProductService.getProduct(this.Id)
        .subscribe(data => (
          this.existingProduct = data,
          this.form.controls[this.formTitle].setValue(data.Name),
          this.form.controls[this.formBody].setValue(data.Quantity)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let Product: Product = {
        Name: this.form.get(this.formTitle)!.value,
        Quantity: this.form.get(this.formBody)!.value,
        Language: 'English',
        Category:'New'
      };

      this.ProductService.saveProduct(Product)
        .subscribe((data) => {
          this.router.navigate(['/Product', data.Id]);
        });
    }

    if (this.actionType === 'Edit') {
      let Product: Product = {
        Id: this.existingProduct.Id,
        Name: this.form.get(this.formTitle)!.value,
        Quantity: this.form.get(this.formBody)!.value,
        Language: this.existingProduct.Language,
        Category:"New"
      };
      this.ProductService.updateProduct(this.Id, Product)
        .subscribe((data) => {
          this.router.navigate([this.router.url]);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get title() { return this.form.get(this.formTitle); }
  get body() { return this.form.get(this.formBody); }
}
