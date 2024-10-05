import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFilterComponent } from '../product-filter/product-filter.component';
import { Product } from '../../../../shared/models/product/product.model';
import { Category } from '../../../../shared/models/category/category.model';

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

  constructor() {}

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
