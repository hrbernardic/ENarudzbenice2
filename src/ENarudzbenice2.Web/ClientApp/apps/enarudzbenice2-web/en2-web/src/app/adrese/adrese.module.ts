import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdreseComponent } from './adrese.component';
import { AdreseRoutingModule } from './adrese-routing.module';
import { DatatableModule } from '@en2/datatable/datatable.module';
import { AdreseClient } from '@en2/enarudzbenice2-api';
import { MaterialModule } from '@en2/material.module';
import { SharedModule } from '@en2/shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    DatatableModule,
    MaterialModule,
    SharedModule,
    AdreseRoutingModule
  ],
  declarations: [AdreseComponent],
  providers: [AdreseClient]
})
export class AdreseModule { }
