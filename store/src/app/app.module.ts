import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HeaderComponent } from "./views/theme/header/header.component";
import { FooterComponent } from "./views/theme/footer/footer.component";
import { HomeComponent } from "./views/pages/home/home.component";
import { ProductDetailComponent } from "./views/pages/product/product-detail/product-detail.component";
import { ProductListComponent } from "./views/pages/product/product-list/product-list.component";
import { CartComponent } from "./views/pages/cart/cart.component";
import { CheckoutComponent } from "./views/pages/checkout/checkout.component";
import { CarouselComponent } from "./views/theme/carousel/carousel.component";
import { HttpClientModule } from "@angular/common/http";
import { BlogListComponent } from "./views/pages/blog/blog-list/blog-list.component";
import { BlogDetailComponent } from "./views/pages/blog/blog-detail/blog-detail.component";
import { AboutComponent } from './views/pages/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    ProductDetailComponent,
    ProductListComponent,
    CartComponent,
    CheckoutComponent,
    CarouselComponent,
    BlogListComponent,
    BlogDetailComponent,
    AboutComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [
    HeaderComponent,
    CarouselComponent,
    FooterComponent,
    HomeComponent,
    ProductListComponent,
    ProductDetailComponent,
    CheckoutComponent,
    CartComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
