import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-nav-link',
  templateUrl: './nav-link.component.html',
  styleUrls: ['./nav-link.component.styl']
})
export class NavLinkComponent implements OnInit {

  @Input() link: string;
  @Input() name: string;
  @Input() role: string;

  constructor() { }

  ngOnInit() {
  }

  canAccess() {
    return true;
  }

}
