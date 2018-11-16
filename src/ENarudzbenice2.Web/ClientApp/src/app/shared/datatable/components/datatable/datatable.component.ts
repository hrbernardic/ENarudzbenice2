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
import { tap } from 'rxjs/internal/operators/tap';
import { merge } from 'rxjs/internal/observable/merge';

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
    this.dataSource.loadData(0, 10, '', '');
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        tap(() =>
          this.dataSource.loadData(
            this.paginator.pageIndex,
            this.paginator.pageSize,
            this.sort.active,
            this.sort.direction
          )
        )
      )
      .subscribe();
  }

  ngAfterContentInit() {
    this.displayedColumns = this.columns.map(c => c.prop);
  }
}
