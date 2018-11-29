import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TestRouteComponent } from './test-route.component';
import { Shell } from '@en2/shell/shell.service';


const routes: Routes = [
  Shell.childRoutes([
    { path: 'Test', component: TestRouteComponent },
    { path: '', redirectTo: '/Test', pathMatch: 'full' }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class TestRoutingModule {}
