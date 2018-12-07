import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentCardComponent } from './content-card/content-card.component';
import { MaterialModule } from '@en2/material.module';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [ContentCardComponent],
  exports: [
    ContentCardComponent
  ]
})
export class SharedModule { }
