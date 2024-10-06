import { Component } from '@angular/core';
import { ProductCardComponent } from '../../../../shared/components/products/product-card/product-card.component';
import { ProductListComponent } from '../../../../shared/components/products/product-list/product-list.component';
import { forkJoin } from 'rxjs';
import { ProductService } from '../../services/product.service';
import { Product } from '../../../../shared/models/product/product.model';
import { Category } from '../../../../shared/models/category/category.model';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [ProductCardComponent, ProductListComponent],
  templateUrl: './product-edit-page.component.html',
  styleUrl: './product-edit-page.component.scss',
})
export class ProductEditComponent {
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
      products: this.productService.getAllProducts(),
    }).subscribe(({ categories, products }) => {
      this.categories = categories;
      this.mapCategories(); // Map category IDs to names
      this.products = products;
    });
  }

  mapCategories(): void {
    this.categories.forEach((category) => {
      this.categoryMap[category.id] = category.name;
    });
  }

  onDeleteProduct(productId: number): void {
    // this.productService.deleteProduct(productId).subscribe(() => {
    //   this.products = this.products.filter(
    //     (product) => product.id !== productId
    //   );
    // });
  }
}
