import { Component, OnInit } from '@angular/core';

import { environment } from '@env/environment';
import { AdreseClient, Adresa } from '@app/shared';
import { Observable } from 'rxjs/internal/Observable';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-adrese',
  templateUrl: './adrese.component.html',
  styleUrls: ['./adrese.component.scss']
})
export class AdreseComponent implements OnInit {
  version: string = environment.version;
  adrese: Adresa[];
  displayedColumns: string[] = ['sifra', 'naziv'];
  dataSource: any;

  constructor(adreseClient: AdreseClient) {
    adreseClient.getAll().subscribe(adrese => {
      this.dataSource = adrese;
    });
  }

  ngOnInit() {}
}
