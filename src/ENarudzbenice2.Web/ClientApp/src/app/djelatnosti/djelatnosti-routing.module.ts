import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Shell } from '@app/shell/shell.service';
import { DjelatnostiComponent } from './djelatnosti.component';

const routes: Routes = [
  Shell.childRoutes([{ path: 'djelatnosti', component: DjelatnostiComponent, data: { title: 'djelatnosti' } }])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class DjelatnostiRoutingModule {}
