import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouteReuseStrategy, RouterModule } from '@angular/router';
import { RouteReusableStrategy } from './routing/route-reusable-strategy';
import { AuthClient } from '../enarudzbenice2-api';
import { AuthenticationGuard } from './authentication/authentication.guard';
import { AuthenticationService } from './authentication/authentication.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@NgModule({
  imports: [CommonModule, HttpClientModule, RouterModule],
  providers: [
    AuthenticationService,
    AuthenticationGuard,
    {
      provide: RouteReuseStrategy,
      useClass: RouteReusableStrategy
    },
    AuthClient
  ]
})
export class CoreModule {
  constructor(
    @Optional()
    @SkipSelf()
    parentModule: CoreModule
  ) {
    // Import guard
    if (parentModule) {
      throw new Error(`${parentModule} has already been loaded. Import Core module in the AppModule only.`);
    }
  }
}
