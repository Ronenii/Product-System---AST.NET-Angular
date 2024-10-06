import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor() {}

  getDecodedToken(token: string): any {
    try {
      return jwtDecode(token);
    } catch (Error) {
      return null;
    }
  }

  getUsernameFromToken(token: string): string {
    const decodedToken = this.getDecodedToken(token);
    return decodedToken
      ? decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
        ]
      : null;
  }

  getRoleFromToken(token: string): string {
    const decodedToken = this.getDecodedToken(token);
    return decodedToken
      ? decodedToken[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        ]
      : null;
  }
}
