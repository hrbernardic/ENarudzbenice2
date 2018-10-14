import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '@app/material.module';
import { AdreseRoutingModule } from './adrese-routing.module';
import { AdreseComponent } from './adrese.component';
import { AdreseClient } from '@app/shared';

@NgModule({
  imports: [CommonModule, FlexLayoutModule, MaterialModule, AdreseRoutingModule],
  declarations: [AdreseComponent],
  providers: [AdreseClient]
})
export class AdreseModule {}
