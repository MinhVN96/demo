import { Component, OnInit } from '@angular/core';
import {ProductService} from '../shared/product.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private productService : ProductService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.productService.selectedProduct = {
      ProductID: null,
      Name: '',
      CategoryID:null,
      WarehouseID:null,
      Brand: '',
      Price: null,
      Count: null,
      Image: '',
      Status:''
    }
  }
 
  onSubmit(form: NgForm) {
    if (form.value.ProductID == null) {
      this.productService.postProduct(form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.productService.getProductList();
          this.toastr.success('New Record Added Succcessfully', 'Product Register');
        })
    }
    else {
      this.productService.putProduct(form.value.EmployeeID, form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.productService.getProductList();
        this.toastr.info('Record Updated Successfully!', 'Product Register');
      });
    }
  }
}
