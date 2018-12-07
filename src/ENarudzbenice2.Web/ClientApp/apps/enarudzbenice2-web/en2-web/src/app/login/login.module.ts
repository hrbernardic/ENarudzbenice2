import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { MaterialModule } from '@en2/material.module';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, FlexLayoutModule, LoginRoutingModule, MaterialModule],
  declarations: [LoginComponent]
})
export class LoginModule {}
