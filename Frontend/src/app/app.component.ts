import { Component } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [RouterModule, SidebarComponent, CommonModule],
})
export class AppComponent {
  title = 'Store';
  constructor(public router: Router) {}
}
