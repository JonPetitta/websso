import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.styl']
})
export class LogoutComponent implements OnInit {

  constructor(private identityService: IdentityService,
              private router: Router) { }

  ngOnInit() {
    this.identityService.logout();
    this.router.navigate(['']);
  }

}
