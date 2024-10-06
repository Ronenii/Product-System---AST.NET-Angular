import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductCardComponent } from '../product-card/product-card.component';
import { Product } from '../../../models/product/product.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [ProductCardComponent, CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent {
  @Input() products: Product[] = [];
  @Input() categoryMap: { [key: number]: string } = {};
  @Input() isDeletable: boolean = false;
  @Output() deleteProduct = new EventEmitter<number>();

  onDelete(productId: number): void {
    this.deleteProduct.emit(productId);
  }
  getCategoryName(categoryId: number): string {
    return this.categoryMap[categoryId] || 'Unknown Category';
  }
}
