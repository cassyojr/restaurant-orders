import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            url: this.url(request.url),
            setHeaders: {
                'Content-Type': 'application/json'
            },
            reportProgress: true
        });

        return next.handle(request);
    }

    private url(method: string) {
        return environment.apiUrl + (method.startsWith('/') ? method : `/${method}`);
    }
}
