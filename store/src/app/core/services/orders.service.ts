import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

const API_URL = "https://localhost:5001/api/order";

@Injectable({
  providedIn: "root"
})
export class OrderstService {
  constructor(private http: HttpClient) {}

  addOrders(customer, productsOrder) {
    return this.http
      .post(API_URL, {
        customer: customer,
        productSelections: productsOrder
      })
      .subscribe(response => {});
  }
}
