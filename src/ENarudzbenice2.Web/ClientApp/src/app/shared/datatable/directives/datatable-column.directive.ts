import { Directive, Input, ContentChild } from '@angular/core';
import { DatatableColumnCellDirective } from './datatable-column-cell.directive';
import { DatatableColumnHeaderDirective } from './datatable-column-header.directive';

@Directive({
  // tslint:disable-next-line:directive-selector
  selector: 'en2-datatable-column'
})
export class DatatableColumnDirective {
  @Input()
  header: string;
  @Input()
  prop: string;

  @ContentChild(DatatableColumnCellDirective)
  cellTpl: DatatableColumnCellDirective;
  @ContentChild(DatatableColumnHeaderDirective)
  headerTpl: DatatableColumnHeaderDirective;

  constructor() {}
}
