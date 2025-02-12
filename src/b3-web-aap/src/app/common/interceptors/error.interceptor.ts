import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ApiResponse } from '../models/api-response';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    private formatErrorResponse(error: HttpErrorResponse): ApiResponse {

        let errors: string[] = ['Ocorreu um erro inesperado no sistema, detalhes foram registrados.'];

        if (error.status !== 400 && error.status !== 404 && error.status !== 500) {
            return { success: false, errors, data: null };
        }

        return error.error;

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
        return next.handle(req).pipe(
            catchError((error: HttpErrorResponse) => {
                const formattedError = this.formatErrorResponse(error);

                console.error('Erro HTTP:', formattedError.errors);

                return of(formattedError);
            })
        );
    }
}






