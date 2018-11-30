import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { TopNavComponent } from './top-nav/top-nav.component';
import { MaterialModule } from '@en2/material.module';
import { RouterModule } from '@angular/router';
import { MenuListItemComponent } from './menu-list-item/menu-list-item.component';
import { NavService } from './nav.service';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SideNavItemComponent } from './side-nav/side-nav-item/side-nav-item.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule
  ],
  declarations: [ShellComponent, TopNavComponent, MenuListItemComponent, SideNavComponent, SideNavItemComponent],
  providers: [NavService]
})
export class ShellModule { }
