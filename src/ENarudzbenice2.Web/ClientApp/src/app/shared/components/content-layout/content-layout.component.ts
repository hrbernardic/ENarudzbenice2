import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'en2-content-layout',
  templateUrl: './content-layout.component.html',
  styleUrls: ['./content-layout.component.scss']
})
export class ContentLayoutComponent implements OnInit {
  @Input()
  title: string;

  constructor() {}

  ngOnInit() {}
}
