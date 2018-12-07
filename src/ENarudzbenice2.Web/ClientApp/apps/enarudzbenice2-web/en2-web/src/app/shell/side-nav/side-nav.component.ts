import { ObservableMedia } from '@angular/flex-layout';
import { Component, ViewChild, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { NavItem } from '../nav-item';
import { AuthenticationService } from '@en2/core';
import { Router } from '@angular/router';

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

  constructor(
    private media: ObservableMedia,
    private changeDetectorRef: ChangeDetectorRef,
    private router: Router,
    private authenticationService: AuthenticationService) { }

  get isMobile(): boolean {
    return this.media.isActive('xs') || this.media.isActive('sm');
  }

  routeChanged() {
    if(this.isMobile) {
      this.isExpanded = false;
    }
  }

  menuButtonClick() {
    if(this.isMobile && this.isExpanded) {
      this.isExpanded = false;
      this.changeDetectorRef.detectChanges();
    }
    this.isExpanded = this.isMobile || !this.isExpanded;
  }

  logout() {
    this.authenticationService.logout().subscribe(() => this.router.navigate(['/Login'], { replaceUrl: true }));
  }

  get username(): string | null {
    const credentials = this.authenticationService.credentials;
    return credentials ? credentials.username : null;
  }

  get userDisplayName(): string | null {
    const credentials = this.authenticationService.credentials;
    return credentials ? credentials.displayName : null;
  }
}
