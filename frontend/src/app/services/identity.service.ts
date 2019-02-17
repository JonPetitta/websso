import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { Identity } from '../models/identity';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  public identitySubject = new BehaviorSubject<Identity>(null);
  private hasIdentity = false;

  constructor(private authService: AuthService) {
    const identity = JSON.parse(localStorage.getItem('identity'));

    if (null !== identity) {
      this.identitySubject.next(identity);
      this.hasIdentity = true;
    }
  }

  public isAuthorized(): boolean {
    return this.hasIdentity;
  }

  public login() {
    this.fetchIdentity();
  }

  public logout() {
    this.authService.logout()
    .subscribe(() => {
      this.hasIdentity = false;
      localStorage.removeItem('identity');
      this.identitySubject.next(null);
    });
  }

  private fetchIdentity(): void {
    this.authService.getIdentity()
    .subscribe((identity: Identity) => {
      localStorage.setItem('identity', JSON.stringify(identity));
      this.identitySubject.next(identity);
      this.hasIdentity = true;
    }, (error) => {
      this.hasIdentity = false;
      this.identitySubject.error(error);
    });
  }
}
