import { inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../../../shared/models/product/product.model';
import { Category } from '../../../shared/models/category/category.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { Filter } from '../../../shared/models/product/filter/filter.model';
import { CreateProductBody } from '../../../shared/models/request-body/create-product.model';
import { createCategoryBody } from '../../../shared/models/request-body/create-category.mode';

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
    return this.http.get<Category[]>(this.categoriesUrl);
  }

  getFilteredProducts(filters: Filter): Observable<Product[]> {
    return this.http.post<Product[]>(this.productsUrl + '/Filter', filters);
  }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl);
  }

  createProduct(product: CreateProductBody): Observable<Product> {
    return this.http.post<Product>(this.productsUrl, product);
  }

  createCategory(category: createCategoryBody): Observable<Category> {
    return this.http.post<Category>(this.categoriesUrl, category);
  }

  deleteProduct(id: number): Observable<any> {
    const url = `${this.productsUrl}/${id}`;
    return this.http.delete(url);
  }
}
