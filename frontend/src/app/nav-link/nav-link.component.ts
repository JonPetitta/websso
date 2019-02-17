import { Component, OnInit, Input } from '@angular/core';
import { Identity } from '../models/identity';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-nav-link',
  templateUrl: './nav-link.component.html',
  styleUrls: ['./nav-link.component.styl']
})
export class NavLinkComponent implements OnInit {

  @Input() link: string;
  @Input() name: string;
  @Input() role: string;

  constructor(private identityService: IdentityService) { }

  ngOnInit() {
    
  }

  public canAccess(): boolean {
    if (undefined === this.role) {
      return true;
    }

    if (this.identityService.isAuthorized()) {
      return this.identityService
        .identitySubject.value
        .roles.indexOf(this.role) > -1;
    }

    return false;
  }

}
