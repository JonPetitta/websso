import { Component, OnInit } from '@angular/core';
import { Identity } from '../models/identity';
import { Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-saml2',
  templateUrl: './saml2.component.html',
  styleUrls: ['./saml2.component.styl']
})
export class Saml2Component implements OnInit {

  constructor(private identityService: IdentityService,
              private router: Router) { }

  ngOnInit() {
    this.identityService.login();
    this.router.navigate(['']);
  }

}
