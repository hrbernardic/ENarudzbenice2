import {
  Component,
  OnInit,
  Input,
  ViewChild,
  AfterContentInit,
  ContentChildren,
  QueryList,
  AfterViewInit,
  ElementRef
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DatatableColumnDirective } from '../../directives/datatable-column.directive';
import { GenericDatasource } from '../../generic-datasource';
import { rowAnimation } from '../../animations/row-animation';
import { tutorialAnimation } from '../../animations/tutorial-animation';
import { fadeInFadeOutAnimation } from '../../animations/fadein-fadeout-animation';
import { tap } from 'rxjs/internal/operators/tap';
import { merge } from 'rxjs/internal/observable/merge';
import { TableQueryRequest } from '@app/shared/enarudzbenice2-api';
import { fromEvent } from 'rxjs/internal/observable/fromEvent';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'en2-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss'],
  animations: [rowAnimation, fadeInFadeOutAnimation]
})
export class DatatableComponent implements OnInit, AfterContentInit, AfterViewInit {
  @Input()
  heading: string;
  @Input()
  dataService: any;

  @ContentChildren(DatatableColumnDirective)
  columns: QueryList<DatatableColumnDirective>;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  @ViewChild(MatSort)
  sort: MatSort;
  @ViewChild('globalFilterInput')
  globalFilterInput: ElementRef;

  dataSource: GenericDatasource;
  displayedColumns: string[];

  tutorialAnimationState = true;
  constructor() {}

  ngOnInit() {
    this.dataSource = new GenericDatasource(this.dataService, this.paginator, this.sort);
    this.dataSource.loadData(
      new TableQueryRequest({
        pageIndex: 0,
        pageSize: 10,
        sortProperty: '',
        sortOrder: '',
        globalFilter: ''
      })
    );
  }

  ngAfterViewInit() {
    fromEvent(this.globalFilterInput.nativeElement, 'keyup')
      .pipe(
        debounceTime(250),
        distinctUntilChanged(),
        tap(() => {
          this.paginator.pageIndex = 0;
          this.loadData();
        })
      )
      .subscribe();

    this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(tap(() => this.loadData()))
      .subscribe();
  }

  ngAfterContentInit() {
    this.displayedColumns = ['actions', ...this.columns.map(c => c.prop)];
    // this.displayedColumns.unshift('actions');
  }

  loadData() {
    this.dataSource.loadData(
      new TableQueryRequest({
        pageIndex: this.paginator.pageIndex,
        pageSize: this.paginator.pageSize,
        sortProperty: this.sort.active,
        sortOrder: this.sort.direction,
        globalFilter: this.globalFilterInput.nativeElement.value
      })
    );
  }
}
