import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NavItem } from '@en2/shell/nav-item';
import { Router } from '@angular/router';
import { NavService } from '@en2/shell/nav.service';
import { trigger, state, transition, animate, style } from '@angular/animations';

@Component({
  selector: 'en2-side-nav-item',
  templateUrl: './side-nav-item.component.html',
  styleUrls: ['./side-nav-item.component.scss'],
  animations: [
      trigger('rotatedState', [
        state('default', style({ transform: 'rotate(0)' })),
        state('rotated', style({ transform: 'rotate(-180deg)' })),
        transition('rotated => default', animate('400ms ease-out')),
        transition('default => rotated', animate('300ms ease-in'))
    ])
  ]

})
export class SideNavItemComponent implements OnInit {
  public expanded: boolean;

  @Input() item: NavItem;
  @Input() depth: number;

  @Output() routeChanged: EventEmitter<any> = new EventEmitter();

  constructor(public router: Router, private navService: NavService) {
    this.depth = this.depth === undefined ? 0 : this.depth;
   }

  ngOnInit() {
    this.navService.currentUrl.subscribe((url: string) => {
      if (this.item.route && url) {
        // console.log(`Checking '/${this.item.route}' against '${url}'`);
        this.expanded = url.indexOf(`/${this.item.route}`) === 0;
        // console.log(`${this.item.route} is expanded: ${this.expanded}`);
      }
    });
  }

  onItemSelected(item: NavItem) {
    if (!item.children || !item.children.length) {
      this.router.navigate([item.route]);
      this.routeChanged.emit();
    }
    if (item.children && item.children.length) {
      this.expanded = !this.expanded;
    }
  }
}
