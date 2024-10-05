import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-link-button',
  standalone: true,
  templateUrl: './link-button.component.html',
  styleUrls: ['./link-button.component.scss'],
})
export class LinkButtonComponent {
  @Input() text: string = '';
  @Output() clicked = new EventEmitter<void>();

  onClick() {
    this.clicked.emit();
  }
}
