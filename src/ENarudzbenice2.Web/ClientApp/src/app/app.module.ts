import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeModule } from './home/home.module';
import { ShellModule } from './shell/shell.module';
import { AdreseModule } from './adrese/adrese.module';
import { LoginModule } from './login/login.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material.module';
import { DjelatnostiModule } from './djelatnosti/djelatnosti.module';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    CoreModule,
    SharedModule,
    ShellModule,
    HomeModule,
    AdreseModule,
    LoginModule,
    DjelatnostiModule,
    AppRoutingModule // must be imported as the last module as it contains the fallback route
  ],
  declarations: [AppComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
