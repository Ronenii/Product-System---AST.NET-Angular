import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFilterComponent } from '../product-filter/product-filter.component';
import { Product } from '../../../../shared/models/product/product.model';
import { Category } from '../../../../shared/models/category/category.model';
import { ProductService } from '../../services/product.service';
import { forkJoin } from 'rxjs';
import { ProductCardComponent } from '../../../../shared/components/products/product-card/product-card.component';
import { ProductListComponent } from '../../../../shared/components/products/product-list/product-list.component';

@Component({
  selector: 'app-product-view-page',
  standalone: true,
  imports: [
    CommonModule,
    ProductFilterComponent,
    ProductCardComponent,
    ProductListComponent,
  ],
  templateUrl: './product-view-page.component.html',
  styleUrl: './product-view-page.component.scss',
})
export class ProductViewPageComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  categoryMap: { [key: number]: string } = {};

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadCategoriesAndProducts();
  }

  loadCategoriesAndProducts(): void {
    forkJoin({
      categories: this.productService.getCategories(),
      products: this.productService.getFilteredProducts({}),
    }).subscribe(({ categories, products }) => {
      this.categories = categories;
      this.mapCategories();
      this.products = products;
    });
  }

  mapCategories(): void {
    this.categories.forEach((category) => {
      this.categoryMap[category.id] = category.name;
    });
  }

  getCategoryName(categoryId: number): string {
    return this.categoryMap[categoryId];
  }

  loadCategories(): void {
    this.productService.getCategories().subscribe((categories) => {
      this.categories = categories;
    });
    this.mapCategories();
  }

  loadFilteredProducts(filters: any): void {
    this.productService.getFilteredProducts(filters).subscribe((products) => {
      this.products = products;
    });
  }

  onFilterChange(filters: any): void {
    this.loadFilteredProducts(filters);
  }
}
