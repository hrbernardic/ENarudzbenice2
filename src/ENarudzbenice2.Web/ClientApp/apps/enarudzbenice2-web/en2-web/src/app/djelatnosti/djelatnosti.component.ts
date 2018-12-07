import { Component, OnInit } from '@angular/core';
import { DjelatnostiClient } from '@en2/enarudzbenice2-api';

@Component({
  selector: 'en2-djelatnosti',
  templateUrl: './djelatnosti.component.html',
  styleUrls: ['./djelatnosti.component.scss']
})
export class DjelatnostiComponent implements OnInit {

  constructor(public djelatnostiClient: DjelatnostiClient) { }

  ngOnInit() {
  }

}
