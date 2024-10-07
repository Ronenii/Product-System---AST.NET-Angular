import { Component } from '@angular/core';
import { ProductCardComponent } from '../../../../shared/components/products/product-card/product-card.component';
import { ProductListComponent } from '../../../../shared/components/products/product-list/product-list.component';
import { forkJoin } from 'rxjs';
import { ProductService } from '../../services/product.service';
import { Product } from '../../../../shared/models/product/product.model';
import { Category } from '../../../../shared/models/category/category.model';
import { CommonModule } from '@angular/common';
import { ProductAddComponent } from '../product-add/product-add.component';
import { CategoryAddComponent } from '../category-add/category-add.component';
import { AuthService } from '../../../../core/auth/auth.service';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [
    ProductListComponent,
    CommonModule,
    ProductAddComponent,
    CategoryAddComponent,
  ],
  templateUrl: './product-edit-page.component.html',
  styleUrl: './product-edit-page.component.scss',
})
export class ProductEditComponent {
  products: Product[] = [];
  categories: Category[] = [];
  categoryMap: { [key: number]: string } = {};
  isDeleteProductsVisible: boolean = false;
  isAddProductsVisible: boolean = false;
  isAddCategoryVisible: boolean = false;

  constructor(
    private productService: ProductService,
    private authService: AuthService
  ) {}

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

  displayDeleteProductsList(): void {
    this.isDeleteProductsVisible = true;
    this.isAddProductsVisible = false;
    this.isAddCategoryVisible = false;
  }

  displayAddProductsForm(): void {
    this.isAddProductsVisible = true;
    this.isAddCategoryVisible = false;
    this.isDeleteProductsVisible = false;
  }

  displayAddCategoriesForm(): void {
    this.isAddCategoryVisible = true;
    this.isAddProductsVisible = false;
    this.isDeleteProductsVisible = false;
  }

  onDeleteProduct(productId: number) {
    this.productService.deleteProduct(productId).subscribe(() => {
      this.products = this.products.filter(
        (product) => product.id !== productId
      );
    });
  }
}
