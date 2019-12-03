import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { BaseComponent } from "./admin/view/theme/base/base.component";
import { AuthGuard } from "./admin/core/guard/auth.guard";

const routes: Routes = [
  {
    path: "admin",
    loadChildren: () =>
      import("./admin/view/pages/auth/auth.module").then(m => m.AuthModule)
  },
  {
    path: "",
    component: BaseComponent,
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {
        path: "dashboard",
        loadChildren: () =>
          import("./admin/view/pages/dashboard/dashboard.module").then(
            m => m.DashboardModule
          )
      },
      {
        path: "catalogs",
        loadChildren: () =>
          import("./admin/view/pages/catalogs/catalogs.module").then(
            m => m.CatalogsModule
          )
      },
      {
        path: "products",
        loadChildren: () =>
          import("./admin/view/pages/products/products.module").then(
            m => m.ProductsModule
          )
      },
      {
        path: "categories",
        loadChildren: () =>
          import("./admin/view/pages/categories/categories.module").then(
            m => m.CategoriesModule
          )
      },
      {
        path: "posts",
        loadChildren: () =>
          import("./admin/view/pages/posts/posts.module").then(
            m => m.PostsModule
          )
      },
      {
        path: "orders",
        loadChildren: () =>
          import("./admin/view/pages/orders/orders.module").then(
            m => m.OrdersModule
          )
      },
      { path: "", redirectTo: "dashboard", pathMatch: "full" },
      { path: "**", redirectTo: "dashboard", pathMatch: "full" }
    ]
  },
  { path: "**", redirectTo: "admin", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
