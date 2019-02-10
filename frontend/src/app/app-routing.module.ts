import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SupervisorComponent } from './supervisor/supervisor.component';
import { AdministratorComponent } from './administrator/administrator.component';
import { Saml2Component } from './saml2/saml2.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'user',
    component: UserComponent,
    canActivate: [AuthGuard],
    canLoad: [AuthGuard],
    data: {
      expectedRole: 'user'
    }
  },
  { path: 'sup',
    component: SupervisorComponent,
    canActivate: [AuthGuard],
    canLoad: [AuthGuard],
    data: {
      expectedRole: 'supervisor'
    }
  },
  { path: 'admin',
    component: AdministratorComponent,
    canActivate: [AuthGuard],
    canLoad: [AuthGuard],
    data: {
      expectedRole: 'administrator'
    }
  },
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
