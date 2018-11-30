import { ObservableMedia } from '@angular/flex-layout';
import { Component, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { NavItem } from '../nav-item';

@Component({
  selector: 'en2-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent {
  @Input() items: NavItem[];
  @Input() isExpanded = true;

  @ViewChild('sidenav') sidenav: MatSidenav;
  isShowing = false;

  constructor(private media: ObservableMedia) { }

  get isMobile(): boolean {
    return this.media.isActive('xs') || this.media.isActive('sm');
  }

  routeChanged() {
    if(this.isMobile) {
      this.isExpanded = false;
    }
  }

}
