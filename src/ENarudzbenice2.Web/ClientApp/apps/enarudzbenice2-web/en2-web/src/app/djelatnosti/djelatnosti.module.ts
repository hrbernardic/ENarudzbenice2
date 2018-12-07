import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '@en2/material.module';
import { DjelatnostiComponent } from './djelatnosti.component';
import { DjelatnostiRoutingModule } from './djelatnosti-routing.module';
import { DatatableModule } from '@en2/datatable/datatable.module';
import { DjelatnostiClient } from '@en2/enarudzbenice2-api';
import { SharedModule } from '@en2/shared/shared.module';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, FlexLayoutModule, DjelatnostiRoutingModule, MaterialModule, DatatableModule, SharedModule],
  declarations: [DjelatnostiComponent],
  providers: [
    DjelatnostiClient
  ]
})
export class DjelatnostiModule {}
