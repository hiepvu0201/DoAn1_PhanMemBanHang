import { BaseModel } from "./base.model";
import { CategorieModel } from "./categories.mode";

export class PostModel extends BaseModel {
  name?: string;
  shortDescription?: string;
  content?: string = "";
  image?: string;
  categoryId?: number;
  category: CategorieModel;
}
