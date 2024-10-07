import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { LoginBody } from '../../shared/models/request-body/login.model';
import { RegisterBody } from '../../shared/models/request-body/register.model';
import { environment } from '../../../../environments/environment';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;
  private authUrl = this.apiUrl + '/Authentication';
  constructor(private cookieService: CookieService) {}

  saveToken(token: string): void {
    this.cookieService.set('authToken', token, {
      expires: 1,
      secure: true,
      sameSite: 'Lax',
    });
  }

  getToken(): string | null {
    return this.cookieService.get('authToken');
  }

  clearToken(): void {
    this.cookieService.delete('authToken');
  }

  getDecodedToken(): any {
    try {
      const token = this.getToken();
      return token ? jwtDecode(token) : null; // Corrected decoding logic
    } catch (Error) {
      return null;
    }
  }

  getUsernameFromToken(): string | null {
    const decodedToken = this.getDecodedToken();
    return decodedToken
      ? decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
        ]
      : null;
  }

  getRoleFromToken(): string | null {
    const decodedToken = this.getDecodedToken();
    console.log(decodedToken);
    return decodedToken
      ? decodedToken[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        ]
      : null;
  }

  isAdmin(): boolean | null {
    return this.getRoleFromToken() == 'Admin';
  }

  async login(loginDetails: LoginBody): Promise<boolean> {
    try {
      const response = await firstValueFrom(
        this.http.post<string>(this.authUrl + '/Login', loginDetails, {
          responseType: 'text' as 'json',
        })
      );
      this.saveToken(response);
      console.log('User Logged in successfully');
      return true;
    } catch (error) {
      console.error('Error logging in', error);
      return false;
    }
  }

  async register(registerDetails: RegisterBody): Promise<boolean> {
    try {
      const response = await firstValueFrom(
        this.http.post<string>(this.authUrl + '/Register', registerDetails, {
          responseType: 'text' as 'json',
        })
      );
      this.saveToken(response);
      console.log('User registered in successfully');
      return true;
    } catch (error) {
      console.error('Error registering', error);
      return false;
    }
  }
}
