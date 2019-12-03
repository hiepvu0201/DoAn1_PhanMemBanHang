import { Component, OnInit } from "@angular/core";
import { PostService } from "src/app/core/services/post.service";
import { Post } from "src/app/core/models/post.model";

@Component({
  selector: "app-blog-list",
  templateUrl: "./blog-list.component.html",
  styleUrls: ["./blog-list.component.scss"]
})
export class BlogListComponent implements OnInit {
  posts: Post[] = [];

  constructor(private postService: PostService) {}

  ngOnInit() {
    this.postService.getPostOptions().subscribe(res => (this.posts = res));
  }
}
