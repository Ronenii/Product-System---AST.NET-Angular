import { inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../../../shared/models/product/product.model';
import { Category } from '../../../shared/models/category/category.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { Filter } from '../../../shared/models/product/filter/filter.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = environment.apiUrl;
  private productsUrl = this.apiUrl + '/Product';
  private categoriesUrl = this.apiUrl + '/Category';
  private http = inject(HttpClient);

  constructor() {}

  getCategories(): Observable<Category[]> {
    // const dummyCategories: Category[] = [
    //   { id: 1, name: 'Electronics' },
    //   { id: 2, name: 'Furniture' },
    //   { id: 3, name: 'Clothing' },
    // ];

    // // Simulate an HTTP response using 'of'
    // return of(dummyCategories);

    return this.http.get<Category[]>(this.categoriesUrl);
  }

  getFilteredProducts(filters: Filter): Observable<Product[]> {
    // const dummyProducts: Product[] = [
    //   {
    //     id: 1,
    //     name: 'Laptop',
    //     description: 'High performance',
    //     price: 1200,
    //     stock: 10,
    //     categoryId: 1,
    //   },
    //   {
    //     id: 2,
    //     name: 'Chair',
    //     description: 'Comfortable chair',
    //     price: 150,
    //     stock: 20,
    //     categoryId: 2,
    //   },
    //   {
    //     id: 3,
    //     name: 'T-Shirt',
    //     description: 'Cotton T-shirt',
    //     price: 20,
    //     stock: 100,
    //     categoryId: 3,
    //   },
    // ];

    // return of(dummyProducts);

    return this.http.post<Product[]>(this.productsUrl + '/Filter', filters);
  }
}
