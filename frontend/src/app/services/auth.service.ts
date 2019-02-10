import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Identity } from '../models/identity';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiBase = 'http://localhost:55815/';
  private identityEndpoint = this.apiBase + 'api/auth/identity';

  constructor(private http: HttpClient) { }

  getIdentity(): Observable<Identity> {
    debugger;
    return this.http.get<Identity>(this.identityEndpoint, { withCredentials: true })
    .pipe(
      retry(3), // retry a failed request up to 3 times
      catchError(this.handleError) // then handle the error
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error(error);

    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }
}
