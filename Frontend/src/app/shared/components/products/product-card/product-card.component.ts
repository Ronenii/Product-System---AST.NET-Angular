import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss',
})
export class ProductCardComponent {
  @Input() name: string = '';
  @Input() description: string = '';
  @Input() price: number = 0;
  @Input() stock: number = 0;
  @Input() category: string = '';

  @Output() deleteProduct = new EventEmitter<number>();

  onDelete() {
    this.deleteProduct.emit();
  }
}
