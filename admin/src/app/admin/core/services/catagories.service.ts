import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/operators";

import { CategorieModel } from "../models/categories.mode";

const API_URL = "https://localhost:5001/api/categories";

@Injectable({
  providedIn: "root"
})
export class CategoriesService {
  constructor(private http: HttpClient) {}

  findAllOtions(
    currentPage = 1,
    pageSize = 10,
    sortOrderName = "",
    sortOrder = "asc",
    searchPropertyName = "",
    searchValue = ""
  ): Observable<any> {
    return this.http
      .get(`${API_URL}/options`, {
        params: new HttpParams()
          .set("currentPage", currentPage.toString())
          .set("pageSize", pageSize.toString())
          .set("sortOrderName", sortOrderName)
          .set("sortOrder", sortOrder)
          .set("searchPropertyName", searchPropertyName)
          .set("searchValue", searchValue)
      })
      .pipe(
        map(res => {
          return res;
        })
      );
  }

  getCountCategories(): Observable<any> {
    return this.http.get(`${API_URL}/count`);
  }

  getCategories(id) {
    return this.http.get<CategorieModel>(`${API_URL}/${id}`);
  }

  addCategories(data) {
    return this.http.post<CategorieModel>(API_URL, data);
  }

  updataCategories(id, data) {
    return this.http.put<CategorieModel>(`${API_URL}/${id}`, data);
  }
  deleteCategories(id) {
    return this.http.delete(`${API_URL}/${id}`);
  }
}
