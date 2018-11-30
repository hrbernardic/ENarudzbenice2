import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestRouteComponent } from './test-route.component';
import { TestRoutingModule } from './test-routing.module';

@NgModule({
  imports: [
    CommonModule,
    TestRoutingModule
  ],
  declarations: [TestRouteComponent]
})
export class TestRouteModule { }
