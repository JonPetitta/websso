import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Identity } from '../models/identity';
import { Router } from '@angular/router';

@Component({
  selector: 'app-saml2',
  templateUrl: './saml2.component.html',
  styleUrls: ['./saml2.component.styl']
})
export class Saml2Component implements OnInit {

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
    this.authService.getIdentity().subscribe(
      (identity: Identity) => {
        localStorage.setItem('identity', JSON.stringify(identity));
        this.authService.getToken().subscribe(
          (token: string) => {
            localStorage.setItem('token', token);
            this.router.navigate(['']);
          },
          error => {
            console.error(error);
            this.router.navigate(['']);
          }
        )
      },
      error => {
        console.error(error);
        this.router.navigate(['']);
      }
    );
  }

}
