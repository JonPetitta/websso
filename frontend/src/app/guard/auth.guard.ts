import { Injectable } from '@angular/core';
import { Route,
         Router,
         UrlSegment,
         CanActivate,
         ActivatedRouteSnapshot,
         RouterStateSnapshot,
         CanLoad } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from '../services/identity.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  
  constructor(private router: Router,
              private identityService: IdentityService) { }

  canLoad(route: Route,
          segments: UrlSegment[]): boolean | Observable<boolean> | Promise<boolean> {
    
    if (this.identityService.isAuthorized()) {
      return this.identityService
        .identitySubject.value
        .roles.indexOf(route.data.expectedRole) > -1;
    }
    
    this.router.navigate(['']);
    return false;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    
    if (this.identityService.isAuthorized()) {
      return this.identityService
        .identitySubject.value
        .roles.indexOf(route.data.expectedRole) > -1;
    }
    
    this.router.navigate(['']);
    return false;
  }
}
