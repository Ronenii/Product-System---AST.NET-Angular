import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LinkButtonComponent } from '../../shared/link-button/link-button.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [FormsModule, CommonModule, LinkButtonComponent],
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  isRegistering: boolean = false;
  isAdmin: boolean = false;

  constructor(private cdr: ChangeDetectorRef) {}

  toggleRegister() {
    this.isRegistering = !this.isRegistering;
    this.cdr.detectChanges();
  }

  onSubmit() {
    if (this.isRegistering) {
      console.log('Registering user', {
        username: this.username,
        password: this.password,
        isAdmin: this.isAdmin,
      });
    } else {
      console.log('Logging in user', {
        username: this.username,
        password: this.password,
        isAdmin: this.isAdmin,
      });
    }
  }
}
