import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '@en2/core';
import { ObservableMedia } from '@angular/flex-layout';
import { NavItem } from './nav-item';
import { NavService } from './nav.service';

@Component({
  selector: 'en2-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit, AfterViewInit {
  public isExpanded = true;
  navItems: NavItem[] = [
    {
      displayName: 'Početna',
      iconName: 'home',
      route: 'Home',
      children: []
    },
    {
      displayName: 'novi',
      iconName: 'add',
      route: 'Home2',
      children: [
        {
          displayName: 'dijete',
          iconName: 'edit',
          route: 'Home2',
          children: []
        }
      ]
    },
    {
      displayName: 'Narudžbenice',
      iconName: 'library_books',
      route: 'Narudzbenice',
      children: [
        {
          displayName: 'Pregled',
          iconName: 'view_list',
          route: 'Narudzbenice/Pregled',
          children: []
        },
        {
          displayName: 'Predlošci',
          iconName: 'line_style',
          route: 'Narudzbenice/Predlošci',
          children: []
        },
      ]
    },
    {
      displayName: 'Šifrarnici',
      iconName: 'list',
      route: 'Sifrarnici',
      children: [
        {
          displayName: 'Adrese',
          iconName: 'place',
          route: 'Sifrarnici/Adrese',
          children: []
        },
        {
          displayName: 'Djelatnosti',
          iconName: 'gavel',
          route: 'Sifrarnici/Djelatnosti',
          children: []
        },
      ]
    },
    {
      displayName: 'Upute za uporabu',
      iconName: 'edit',
      route: 'Test',
      children: []
    }
  ]

  constructor(
    private router: Router,
    private media: ObservableMedia,
    private authenticationService: AuthenticationService,
    // private navService: NavService
  ) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    // this.navService.appDrawer = this.appDrawer;
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

  get isMobile(): boolean {
    return this.media.isActive('xs') || this.media.isActive('sm');
  }


}
