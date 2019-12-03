import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";
import { map } from "rxjs/operators";
import { PostModel } from "../models/post.model";

const API_URL = "https://localhost:5001/api/posts";

@Injectable({
  providedIn: "root"
})
export class PostService {
  constructor(private http: HttpClient) {}

  findAllOtions(
    currentPage = 1,
    pageSize = 10,
    sortOrderName: string,
    sortOrder = "asc",
    searchPropertyName: string,
    searchValue: string
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

  getPost(id) {
    return this.http.get<PostModel>(`${API_URL}/${id}`);
  }

  addPost(data) {
    const postData = new FormData();
    postData.append("name", data.name);
    postData.append("shortDescription", data.shortDescription);
    postData.append("content", data.content);
    postData.append("image", data.image);
    postData.append("categoryId", data.categoryId);

    return this.http.post<PostModel>(API_URL, postData);
  }

  editPost(id, data) {
    const postData = new FormData();
    postData.append("name", data.name);
    postData.append("shortDescription", data.shortDescription);
    postData.append("content", data.content);
    postData.append("categoryId", data.categoryId);

    if (data.image) {
      postData.append("image", data.image);
    }

    return this.http.put<PostModel>(`${API_URL}/${id}`, postData);
  }

  deletePost(id) {
    return this.http.delete(`${API_URL}/${id}`);
  }
}
