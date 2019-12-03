import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/operators";
import { CatalogsModel } from "../models/catalogs.model";

const API_URL = "https://localhost:5001/api/catalogs";
const API_URL_OPTIONS = "https://localhost:5001/api/catalogs/options";

@Injectable({
  providedIn: "root"
})
export class CatalogsService {
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
      .get(API_URL_OPTIONS, {
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

  findCatalogById(id) {
    return this.http.get<CatalogsModel>(`${API_URL}\\${id}`);
  }

  addCatalog(data) {
    return this.http.post<CatalogsModel>(API_URL, data);
  }

  updataCatalog(id, data) {
    return this.http.put<CatalogsModel>(`${API_URL}\\${id}`, data);
  }

  deleteCatalog(id) {
    // const httpOtions = {
    //   headers: new HttpHeaders({ "Content-Type": "application/json" })
    // };
    return this.http.delete(`${API_URL}\\${id}`);
  }
}
