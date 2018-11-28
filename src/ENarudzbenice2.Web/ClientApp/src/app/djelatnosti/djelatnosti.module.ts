import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MaterialModule } from '@app/material.module';
import { DjelatnostiRoutingModule } from './djelatnosti-routing.module';
import { DjelatnostiComponent } from './djelatnosti.component';
import { DjelatnostiClient, SharedModule } from '@app/shared';

@NgModule({
  imports: [CommonModule, FlexLayoutModule, MaterialModule, DjelatnostiRoutingModule, SharedModule],
  declarations: [DjelatnostiComponent],
  providers: [DjelatnostiClient]
})
export class DjelatnostiModule {}
