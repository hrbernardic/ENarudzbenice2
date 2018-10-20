import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from '@app/material.module';
import { LoaderComponent } from './loader/loader.component';
import { ActionButtonComponent } from './components/action-button/action-button.component';
import { DatatableModule } from './datatable/datatable.module';
import { ContentLayoutComponent } from './components/content-layout/content-layout.component';

@NgModule({
  imports: [FlexLayoutModule, MaterialModule, CommonModule],
  declarations: [LoaderComponent, ActionButtonComponent, ContentLayoutComponent],
  exports: [LoaderComponent, ActionButtonComponent, DatatableModule, ContentLayoutComponent]
})
export class SharedModule {}
