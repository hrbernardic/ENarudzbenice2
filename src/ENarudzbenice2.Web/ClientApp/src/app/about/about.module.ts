import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '@app/material.module';
import { AboutRoutingModule } from './about-routing.module';
import { AboutComponent } from './about.component';
import { AdreseClient } from '@app/shared';

@NgModule({
  imports: [CommonModule, FlexLayoutModule, MaterialModule, AboutRoutingModule],
  declarations: [AboutComponent],
  providers: [AdreseClient]
})
export class AboutModule {}
