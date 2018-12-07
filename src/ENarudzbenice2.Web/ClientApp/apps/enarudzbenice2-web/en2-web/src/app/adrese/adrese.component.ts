import { Component, OnInit } from '@angular/core';
import { AdreseClient } from '@en2/enarudzbenice2-api';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'en2-adrese',
  templateUrl: './adrese.component.html',
  styleUrls: ['./adrese.component.scss']
})
export class AdreseComponent implements OnInit {

  constructor(public adreseClient: AdreseClient) { }

  ngOnInit() {
  }
}
