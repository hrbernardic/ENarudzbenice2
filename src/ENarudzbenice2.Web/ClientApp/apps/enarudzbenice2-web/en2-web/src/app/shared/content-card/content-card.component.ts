import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'en2-content-card',
  templateUrl: './content-card.component.html',
  styleUrls: ['./content-card.component.scss']
})
export class ContentCardComponent implements OnInit {
  @Input() headerIcon: string;
  @Input() headerText: string;

  constructor() { }

  ngOnInit() {
  }

}
