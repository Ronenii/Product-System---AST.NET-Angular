import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Category } from '../../../../shared/models/category/category.model';
import { Filter } from '../../../../shared/models/product/filter/filter.model';

@Component({
  selector: 'app-product-filter',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './product-filter.component.html',
  styleUrl: './product-filter.component.scss',
})
export class ProductFilterComponent {
  @Input() categories: Category[] = [];
  @Output() filterChange = new EventEmitter<any>();

  filter: Filter = {};

  applyFilters(): void {
    this.filterChange.emit(this.filter);
  }
}
