import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatatableComponent } from './components/datatable/datatable.component';
import { DatatableColumnDirective } from './directives/datatable-column.directive';
import { DatatableColumnCellDirective } from './directives/datatable-column-cell.directive';
import { DatatableColumnHeaderDirective } from './directives/datatable-column-header.directive';
import { DatatableActionColumnDirective } from './directives/datatable-action-column.directive';
import { MaterialModule } from '@en2/material.module';

@NgModule({
  imports: [CommonModule, MaterialModule],
  declarations: [
    DatatableComponent,
    DatatableColumnDirective,
    DatatableColumnCellDirective,
    DatatableColumnHeaderDirective,
    DatatableActionColumnDirective
  ],
  exports: [
    DatatableComponent,
    DatatableColumnDirective,
    DatatableColumnCellDirective,
    DatatableColumnHeaderDirective,
    DatatableActionColumnDirective
  ]
})
export class DatatableModule {}