import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { PostService } from "src/app/core/services/post.service";
import { Post } from "src/app/core/models/post.model";

@Component({
  selector: "app-blog-detail",
  templateUrl: "./blog-detail.component.html",
  styleUrls: ["./blog-detail.component.scss"]
})
export class BlogDetailComponent implements OnInit {
  id: number;
  post: Post;

  constructor(
    private router: ActivatedRoute,
    private postService: PostService
  ) {}

  ngOnInit() {
    this.router.params.subscribe((params: Params) => {
      this.id = +params["id"];
      this.postService.getPost(this.id).subscribe(p => {
        this.post = p;
      });
    });
  }
}
