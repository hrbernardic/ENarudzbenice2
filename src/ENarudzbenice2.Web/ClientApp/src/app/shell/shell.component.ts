import { Title } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ObservableMedia } from '@angular/flex-layout';

import { AuthenticationService } from '@app/core';

@Component({
  selector: 'en2-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {
  constructor(
    private router: Router,
    private titleService: Title,
    private media: ObservableMedia,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit() {}

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

  get isMobile(): boolean {
    return this.media.isActive('xs') || this.media.isActive('sm');
  }

  get title(): string {
    return this.titleService.getTitle();
  }
}
