import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { createCategoryBody } from '../../../../shared/models/request-body/create-category.mode';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.scss',
})
export class CategoryAddComponent {
  categoryForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService
  ) {
    this.categoryForm = this.formBuilder.group({
      name: ['', [Validators.required]],
    });
  }

  onSubmit() {
    if (this.categoryForm.valid) {
      const category: createCategoryBody = this.categoryForm.value;
      this.productService.createCategory(category).subscribe(
        (response) => {
          console.log('Category created successfully:', response);
          this.categoryForm.reset();
        },
        (error) => {
          console.error('Error creating category:', error);
        }
      );
    } else {
      this.categoryForm.markAllAsTouched();
    }
  }

  getForm() {
    return this.categoryForm.controls;
  }
}
