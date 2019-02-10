import { Injectable } from '@angular/core';
import { Route, Router, UrlSegment, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanLoad } from '@angular/router';
import { Observable } from 'rxjs';
import { Identity } from '../models/identity';
import { takeUntil } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  
  private identity: Identity;

  constructor(private router: Router) { }

  canLoad(route: Route,
          segments: UrlSegment[]): boolean | Observable<boolean> | Promise<boolean> {
    this.identity = JSON.parse(localStorage.getItem('identity'));

    if (!(this.identity.roles.indexOf(route.data.expectedRole) > -1)){
      this.router.navigate(['']);
      return false;
    }
    
    return true;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      this.identity = JSON.parse(localStorage.getItem('identity'));

      if (!(this.identity.roles.indexOf(route.data.expectedRole) > -1)){
        this.router.navigate(['']);
        return false;
      }
      
      return true;
  }
}
