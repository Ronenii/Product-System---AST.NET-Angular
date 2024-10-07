import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.scss',
})
export class CategoryAddComponent {
  categoryForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.categoryForm = this.formBuilder.group({
      name: ['', [Validators.required]],
    });
  }

  onSubmit() {
    if (this.categoryForm.valid) {
    } else {
      this.categoryForm.markAllAsTouched();
    }
  }

  getForm() {
    return this.categoryForm.controls;
  }
}
