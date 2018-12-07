import { Directive, TemplateRef } from '@angular/core';

@Directive({
  selector: '[en2DatatableColumnCell]'
})
export class DatatableColumnCellDirective {
  constructor(public templateRef: TemplateRef<any>) {}
}
