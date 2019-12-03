import { BaseModel } from "./base.model";

export class CategorieModel extends BaseModel {
  name: string;
  shortDescription: string;
  description: Text;
  visibility: boolean;
}
