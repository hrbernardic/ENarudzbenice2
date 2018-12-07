import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '@en2/shell/shell.service';
import { AdreseComponent } from './adrese.component';

const routes: Routes = [
  Shell.childRoutes([
    { path: 'Sifrarnici/Adrese', component: AdreseComponent }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class AdreseRoutingModule {}
