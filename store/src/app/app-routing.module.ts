import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./views/pages/home/home.component";
import { ProductDetailComponent } from "./views/pages/product/product-detail/product-detail.component";
import { ProductListComponent } from "./views/pages/product/product-list/product-list.component";
import { CartComponent } from "./views/pages/cart/cart.component";
import { CheckoutComponent } from "./views/pages/checkout/checkout.component";
import { BlogListComponent } from "./views/pages/blog/blog-list/blog-list.component";
import { BlogDetailComponent } from "./views/pages/blog/blog-detail/blog-detail.component";
import { AboutComponent } from "./views/pages/about/about.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "home", component: HomeComponent },
  { path: "products", component: ProductListComponent },
  { path: "product/:id", component: ProductDetailComponent },
  { path: "cart", component: CartComponent },
  { path: "cart/checkout", component: CheckoutComponent },
  { path: "blog", component: BlogListComponent },
  { path: "blog/:id", component: BlogDetailComponent },
  { path: "about", component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
