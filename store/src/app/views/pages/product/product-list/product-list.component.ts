import { Component, OnInit } from "@angular/core";

import { ProductService } from "src/app/core/services/product.service";
import { CatalogService } from "src/app/core/services/catalog.service";
import { Product } from "src/app/core/models/product.model";
import { Catalog } from "src/app/core/models/catalog.model";

@Component({
  selector: "app-product-list",
  templateUrl: "./product-list.component.html",
  styleUrls: ["./product-list.component.scss"]
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  catalogs: Catalog[] = [];

  // OPTIONS GET LIST
  currentPage: number = 1;
  pageSize: number = 10;
  sortOrderName: string = "";
  sortOrder: string = "asc";
  searchPropertyName: string = "";
  searchValue: string = "";

  constructor(
    private productService: ProductService,
    private catalogService: CatalogService
  ) {}

  ngOnInit() {
    this.productService
      .getProductOptions()
      .subscribe(products => (this.products = products));

    this.catalogService
      .getCatalog()
      .subscribe(catalogs => (this.catalogs = catalogs));
  }

  onCatalog(nameCatalog: string) {
    this.searchPropertyName = "catalog.name";
    this.searchValue = nameCatalog;

    this.loadProductOptions();
  }

  onSort(sortOrderName: string, sortOrder: string) {
    this.sortOrderName = sortOrderName;
    this.sortOrder = sortOrder;

    this.loadProductOptions();
  }

  loadProductOptions() {
    this.productService
      .getProductOptions(
        this.currentPage,
        this.pageSize,
        this.sortOrderName,
        this.sortOrder,
        this.searchPropertyName,
        this.searchValue
      )
      .subscribe(products => (this.products = products));
  }
}
