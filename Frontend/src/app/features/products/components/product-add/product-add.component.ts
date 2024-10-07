import { Component, Input } from '@angular/core';
import { Category } from '../../../../shared/models/category/category.model';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product.service';
import { CreateProductBody } from '../../../../shared/models/request-body/create-product.model';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.scss',
})
export class ProductAddComponent {
  productForm: FormGroup;
  @Input() categories: Category[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService
  ) {
    this.productForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: [''],
      price: [
        '',
        [Validators.required, Validators.pattern(/^[0-9]+(\.[0-9]{1,2})?$/)],
      ],
      stock: ['', [Validators.required, Validators.pattern(/^[0-9]/)]],
      categoryId: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      const product: CreateProductBody = this.productForm.value;
      this.productService.createProduct(product).subscribe(
        (response) => {
          console.log('Product created successfully:', response);
          this.productForm.reset();
        },
        (error) => {
          console.error('Error creating product:', error);
        }
      );
    } else {
      this.productForm.markAllAsTouched();
    }
  }

  get getForm() {
    return this.productForm.controls;
  }
}
