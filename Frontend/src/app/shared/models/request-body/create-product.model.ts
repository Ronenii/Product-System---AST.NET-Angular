export interface CreateProductBody {
  name: string;
  description: string;
  price: number;
  stock: number;
  categoryId: number;
}
