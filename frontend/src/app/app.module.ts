import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AuthService } from './services/auth.service';

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

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SupervisorComponent,
    AdministratorComponent,
    HomeComponent,
    Saml2Component,
    AuthNavComponent,
    NavLinkComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatDividerModule
  ],
  providers: [
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
