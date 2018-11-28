import { Component } from '@angular/core';
import { AdreseClient, Adresa } from '@app/shared';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'en2-adrese',
  templateUrl: './adrese.component.html',
  styleUrls: ['./adrese.component.scss']
})
export class AdreseComponent {
  constructor(public adreseClient: AdreseClient) {
    // this.adrese = this.adreseClient.getAll();
  }

  addItem() {
    console.log('Add Item');
  }

  editItem(element: Adresa) {
    console.log('Edit Item: ' + element.id);
  }

  deleteItem(element: Adresa) {
    console.log('Delete Item: ' + element.id);
  }
}
