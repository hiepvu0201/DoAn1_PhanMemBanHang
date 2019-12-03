import { Category } from "./category.model";

export class Post {
  id: number;
  name: string;
  shortDescription: string;
  content: string;
  image: string;
  categoryId: number;
  category: Category;
  createAt: string;
  updateAt: string;
}
