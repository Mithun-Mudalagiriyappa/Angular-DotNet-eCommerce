import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute, private breadcrumbService: BreadcrumbService) { 
    //Number was getting displayed when the data was not yet loaded. Hence setting it to empty
    this.breadcrumbService.set('@productDetails', ''); 
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.params["id"]).subscribe(x => {
      this.product = x;
      this.breadcrumbService.set('@productDetails', this.product.name);
    }, error => {
      console.log(error);
    })
  }
}
