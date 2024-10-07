import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  static token: string =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJyb25lbmlpIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InJvbmVuaWkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImp0aSI6IjNkMzQyYmM5LTg3ODAtNDQ0NC05OTk0LTM1YTVlMzgxNTRhNiIsImV4cCI6MTcyODMyNDk4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3QifQ.nvmTVgNrmj0LfGKKRjWmQp4QKjZtZOIX9cil_c2eIR0';

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
}
