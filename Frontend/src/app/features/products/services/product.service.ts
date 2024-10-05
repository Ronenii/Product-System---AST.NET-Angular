import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../../shared/models/product/product.model';
import { Category } from '../../../shared/models/category/category.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private filterProductsUrl = '/api/Product';
  private categoriesUrl = 'api/Categories';

  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoriesUrl);
  }

  getFilteredProducts(filters: any): Observable<Product[]> {
    return this.http.post<Product[]>(
      this.filterProductsUrl + '/Filter',
      filters
    );
  }
}
