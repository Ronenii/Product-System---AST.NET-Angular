import { Component, OnInit } from '@angular/core';
import { Product } from '../../../features/models/product/product.model';
import { Category } from '../../../features/models/category/category.model';
import { CommonModule } from '@angular/common';
import { ProductFilterComponent } from '../product-filter/product-filter.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, ProductFilterComponent],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  categoryMap: { [key: number]: string } = {};

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadCategories();
    this.loadFilteredProducts({});
  }

  mapCategories(): void {
    this.categories.forEach((category) => {
      this.categoryMap[category.id] = category.name;
    });
  }

  getCategoryName(categoryId: number): string {
    return this.categoryMap[categoryId];
  }

  onFilterChange(filters: any): void {
    this.loadFilteredProducts(filters);
  }
}
