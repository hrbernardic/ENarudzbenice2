import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DjelatnostiComponent } from './djelatnosti.component';
import { Shell } from '@en2/shell/shell.service';

const routes: Routes = [
  Shell.childRoutes([
    { path: 'Sifrarnici/Djelatnosti', component: DjelatnostiComponent }
  ])
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class DjelatnostiRoutingModule {}
