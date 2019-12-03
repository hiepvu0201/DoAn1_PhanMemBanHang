import { BaseModel } from "./base.model";

export class CatalogsModel extends BaseModel {
  name: string;
  shortDescription: string;
  description: Text;
  visibility: boolean;
}
