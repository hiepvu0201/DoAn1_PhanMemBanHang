import { BaseModel } from "./base.model";
import { CatalogsModel } from "./catalogs.model";

export class ProductModel extends BaseModel {
  name?: string;
  shortDescription?: string;
  description?: string = "";
  price?: number;
  image?: string;
  catalogsId?: number;
  catalog: CatalogsModel;
}
