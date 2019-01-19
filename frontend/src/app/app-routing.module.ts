import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SupervisorComponent } from './supervisor/supervisor.component';
import { AdministratorComponent } from './administrator/administrator.component';
import { Saml2Component } from './saml2/saml2.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'user', component: UserComponent },
  { path: 'sup', component: SupervisorComponent },
  { path: 'admin', component: AdministratorComponent },
  { path: 'saml2', component: Saml2Component }
];

@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    { enableTracing: true }
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
