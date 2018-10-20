import { Component } from '@angular/core';
import { DjelatnostiClient, Djelatnost } from '@app/shared';
import { Observable } from 'rxjs';

@Component({
  selector: 'en2-djelatnosti',
  templateUrl: './djelatnosti.component.html',
  styleUrls: ['./djelatnosti.component.scss']
})
export class DjelatnostiComponent {
  constructor(public djelatnostiClient: DjelatnostiClient) {}
}
