import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Identity } from '../models/identity';

@Component({
  selector: 'app-saml2',
  templateUrl: './saml2.component.html',
  styleUrls: ['./saml2.component.styl']
})
export class Saml2Component implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.getIdentity().subscribe(
      (identity: Identity) => {
        localStorage.setItem('identity', JSON.stringify(identity));
      },
      error => console.error(error) // error path
    );
  }

}
