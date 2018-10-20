import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'dd-action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ActionButtonComponent {
  @Input()
  icon: string;
  @Input()
  color: string;
  @Input()
  tooltip: string;

  constructor() {}
}
