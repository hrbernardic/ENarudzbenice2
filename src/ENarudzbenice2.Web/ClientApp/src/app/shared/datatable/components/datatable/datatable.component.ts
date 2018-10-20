import {
  Component,
  OnInit,
  Input,
  ViewChild,
  AfterContentInit,
  ContentChildren,
  QueryList,
  AfterViewInit
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DatatableColumnDirective } from '../../directives/datatable-column.directive';
import { GenericDatasource } from '../../generic-datasource';
import { rowAnimation } from '../../animations/row-animation';
import { tutorialAnimation } from '../../animations/tutorial-animation';
import { fadeInFadeOutAnimation } from '../../animations/fadein-fadeout-animation';

@Component({
  selector: 'en2-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss'],
  animations: [rowAnimation, fadeInFadeOutAnimation]
})
export class DatatableComponent implements OnInit, AfterContentInit, AfterViewInit {
  @Input()
  dataService: any;

  @ContentChildren(DatatableColumnDirective)
  columns: QueryList<DatatableColumnDirective>;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  @ViewChild(MatSort)
  sort: MatSort;

  dataSource: GenericDatasource;
  displayedColumns: string[];

  tutorialAnimationState = true;
  constructor() {}

  ngOnInit() {
    this.dataSource = new GenericDatasource(this.dataService, this.paginator, this.sort);
    this.dataSource.loadData();
  }

  ngAfterViewInit() {
    // this.tutorialAnimationState = false;
  }

  ngAfterContentInit() {
    this.displayedColumns = this.columns.map(c => c.prop);
  }
}
