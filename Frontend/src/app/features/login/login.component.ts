import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LinkButtonComponent } from '../../shared/components/link-button/link-button.component';
import { AuthService } from '../../core/auth/auth.service';
import { LoginBody } from '../../shared/models/request-body/login.model';
import { RegisterBody } from '../../shared/models/request-body/register.model';
import { Router } from '@angular/router';

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

  constructor(
    private cdr: ChangeDetectorRef,
    private authService: AuthService,
    private router: Router
  ) {}

  toggleRegister() {
    this.isRegistering = !this.isRegistering;
    this.cdr.detectChanges();
  }

  async onSubmit() {
    let success: boolean = false;
    if (this.isRegistering) {
      const registerDetails: RegisterBody = {
        username: this.username,
        password: this.password,
        isAdmin: this.isAdmin,
      };

      success = await this.authService.register(registerDetails);
    } else {
      const loginDetails: LoginBody = {
        username: this.username,
        password: this.password,
      };

      success = await this.authService.login(loginDetails);
    }

    if (success) {
      this.router.navigate(['/products']);
    }
  }
}
