import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  static token: string = '';
  constructor(private cookieService: CookieService) {}

  saveToken(token: string): void {
    this.cookieService.set('authToken', token, {
      expires: 1,
      secure: true,
      sameSite: 'Lax',
    });
  }

  getToken(): string | null {
    return AuthService.token;
    // return this.cookieService.get('authToken');
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
}
