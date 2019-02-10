import { Component, OnInit, Input } from '@angular/core';
import { Identity } from '../models/identity';

@Component({
  selector: 'app-nav-link',
  templateUrl: './nav-link.component.html',
  styleUrls: ['./nav-link.component.styl']
})
export class NavLinkComponent implements OnInit {

  @Input() link: string;
  @Input() name: string;
  @Input() role: string;

  private identity: Identity;

  constructor() { }

  ngOnInit() {
    this.identity = JSON.parse(localStorage.getItem('identity'));
  }

  canAccess(): boolean {
    if (undefined === this.role) {
      return true;
    }

    return this.identity.roles.indexOf(this.role) > -1;
  }

}
