import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';
import { Shell } from '@en2/shell/shell.service';


const routes: Routes = [
  Shell.childRoutes([
    // { path: '', redirectTo: '/Home', pathMatch: 'full' },
    { path: 'Home', component: HomeComponent }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class HomeRoutingModule {}
