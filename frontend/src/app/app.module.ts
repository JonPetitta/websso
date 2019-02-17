import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {
  MatButtonModule,
  MatCheckboxModule,
  MatToolbarModule,
  MatDividerModule
} from '@angular/material';
import { UserComponent } from './user/user.component';
import { SupervisorComponent } from './supervisor/supervisor.component';
import { AdministratorComponent } from './administrator/administrator.component';
import { HomeComponent } from './home/home.component';
import { Saml2Component } from './saml2/saml2.component';
import { AuthNavComponent } from './auth-nav/auth-nav.component';
import { NavLinkComponent } from './nav-link/nav-link.component';
import { LogoutComponent } from './logout/logout.component';
import { AuthService } from './services/auth.service';
import { IdentityService } from './services/identity.service';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SupervisorComponent,
    AdministratorComponent,
    HomeComponent,
    Saml2Component,
    AuthNavComponent,
    NavLinkComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatDividerModule
  ],
  providers: [
    AuthService,
    IdentityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
