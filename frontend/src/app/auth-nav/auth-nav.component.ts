import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-auth-nav',
  templateUrl: './auth-nav.component.html',
  styleUrls: ['./auth-nav.component.styl']
})
export class AuthNavComponent implements OnInit {

  @Input() title: string;

  home = {
    link: '/',
    name: 'Home',
    role: 'user'
  };

  user = {
    link: '/user',
    name: 'User',
    role: 'user'
  };

  sup = {
    link: '/sup',
    name: 'Sup',
    role: 'supervisor'
  };

  admin = {
    link: '/admin',
    name: 'Admin',
    role: 'administrator'
  };

  constructor() { }

  ngOnInit() {
  }

}
