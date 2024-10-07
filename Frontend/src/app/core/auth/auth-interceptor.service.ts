import { HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandlerFn, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
  if (AuthService.token) {
    const clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${AuthService.token}`,
      },
    });

    return next(clonedRequest);
  }

  return next(req);
};
