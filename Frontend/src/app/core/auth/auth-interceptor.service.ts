import { HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandlerFn, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
  const token =
    'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJyb25lbmlpIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InJvbmVuaWkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImp0aSI6IjBiZGJkNzlhLTExZGEtNGMxMC05OWI3LWJkODZiNTA0ZDVlZSIsImV4cCI6MTcyODIzMTc5MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3QifQ.NxIpmP_jIEA_VCPxlP9MAox5FYhd20KsiwqjbwKx3N4';

  if (token) {
    const clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });

    return next(clonedRequest);
  }

  return next(req);
};
