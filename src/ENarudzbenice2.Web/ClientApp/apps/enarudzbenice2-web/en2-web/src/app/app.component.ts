import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Title } from '@angular/platform-browser';

import { filter } from 'rxjs/operators';

import { Logger } from './core/logging/logger.service';
import { environment } from '@env/environment';



const log = new Logger('App');

@Component({
  selector: 'en2-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  constructor(private router: Router, private activatedRoute: ActivatedRoute, private titleService: Title) {}

  ngOnInit() {
    // Setup logger
    if (environment.production) {
      Logger.enableProductionMode();
    }

    log.debug('init');

    const onNavigationEnd = this.router.events.pipe(filter(event => event instanceof NavigationEnd));
  }
}
