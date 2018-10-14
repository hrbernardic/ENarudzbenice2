import { Component, OnInit } from '@angular/core';

import { environment } from '@env/environment';
import { AdreseClient, Adresa } from '@app/shared';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  version: string = environment.version;
  adrese: Observable<Adresa[]>;

  constructor(adreseClient: AdreseClient) {
    this.adrese = adreseClient.getAll();
  }

  ngOnInit() {}
}
