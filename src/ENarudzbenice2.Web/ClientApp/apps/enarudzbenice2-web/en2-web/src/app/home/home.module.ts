import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MaterialModule } from '@en2/material.module';
import { CoreModule } from '@en2/core';

@NgModule({
  imports: [CommonModule, CoreModule, FlexLayoutModule, MaterialModule, HomeRoutingModule],
  declarations: [HomeComponent]
})
export class HomeModule {}
