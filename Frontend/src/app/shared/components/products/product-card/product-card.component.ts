import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AuthService } from '../../../../core/auth/auth.service';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss',
})
export class ProductCardComponent {
  @Input() name: string = '';
  @Input() description: string = '';
  @Input() price: number = 0;
  @Input() stock: number = 0;
  @Input() category: string = '';
  @Input() deletable: boolean = false;
  isAdmin: boolean = false;

  @Output() deleteProduct = new EventEmitter<number>();

  constructor(private authService: AuthService) {}

  onDelete() {
    this.deleteProduct.emit();
  }

  getIsAdmin() {
    this.isAdmin = this.authService.getRoleFromToken() == 'Admin';
    return this.isAdmin;
  }
}
