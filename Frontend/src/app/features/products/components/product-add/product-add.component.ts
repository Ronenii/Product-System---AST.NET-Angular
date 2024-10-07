import { Component } from '@angular/core';
import { Category } from '../../../../shared/models/category/category.model';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.scss',
})
export class ProductAddComponent {
  productForm: FormGroup;
  categories: Category[] = [];

  constructor(private formBuilder: FormBuilder) {
    this.productForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: [''],
      price: [
        '',
        [Validators.required, Validators.pattern(/^[0-9]+(\.[0-9]{1,2})?$/)],
      ],
      stock: ['', [Validators.required, Validators.pattern(/^[0-9]/)]],
      category: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      // TODO: Product service call
    } else {
      this.productForm.markAllAsTouched();
    }
  }

  get getForm() {
    return this.productForm.controls;
  }
}
