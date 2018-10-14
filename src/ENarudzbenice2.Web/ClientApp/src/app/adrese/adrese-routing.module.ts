import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Shell } from '@app/shell/shell.service';
import { AdreseComponent } from './adrese.component';

const routes: Routes = [Shell.childRoutes([{ path: 'Adrese', component: AdreseComponent, data: { title: 'Adrese' } }])];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class AdreseRoutingModule {}
