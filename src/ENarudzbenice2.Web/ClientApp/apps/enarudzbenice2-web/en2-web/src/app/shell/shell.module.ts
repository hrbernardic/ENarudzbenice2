import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { TopNavComponent } from './top-nav/top-nav.component';
import { MaterialModule } from '@en2/material.module';
import { RouterModule } from '@angular/router';
import { MenuListItemComponent } from './menu-list-item/menu-list-item.component';
import { NavService } from './nav.service';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule
  ],
  declarations: [ShellComponent, TopNavComponent, MenuListItemComponent],
  providers: [NavService]
})
export class ShellModule { }
