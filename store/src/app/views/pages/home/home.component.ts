import { Component, OnInit } from "@angular/core";

import { Product } from "src/app/core/models/product.model";
import { ProductService } from "src/app/core/services/product.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService
      .getProductsLimit()
      .subscribe(products => (this.products = products));
  }
}
