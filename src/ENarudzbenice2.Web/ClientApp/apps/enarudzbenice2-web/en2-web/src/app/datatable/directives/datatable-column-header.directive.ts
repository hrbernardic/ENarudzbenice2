import { Directive, TemplateRef } from '@angular/core';

@Directive({
  selector: '[en2DatatableColumnHeader]'
})
export class DatatableColumnHeaderDirective {
  constructor(public templateRef: TemplateRef<any>) {}
}
