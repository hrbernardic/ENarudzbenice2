import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable, BehaviorSubject, of, timer } from 'rxjs';
import { finalize, catchError, delay, map, takeUntil, tap } from 'rxjs/operators';

export class GenericDatasource extends DataSource<any> {
  private queryResponseSubject = new BehaviorSubject<any>({});
  private loadingSubject = new BehaviorSubject<boolean>(false);

  // tslint:disable-next-line:member-ordering
  public queryResponse$ = this.queryResponseSubject.asObservable();
  // tslint:disable-next-line:member-ordering
  public loading$ = this.loadingSubject.asObservable();

  constructor(private dataService: any, private paginator: MatPaginator, private sort: MatSort) {
    super();
  }

  connect(collectionViewer: CollectionViewer): Observable<any[]> {
    return this.queryResponseSubject.asObservable().pipe(map(queryResponse => queryResponse.results));
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.queryResponseSubject.complete();
    this.loadingSubject.complete();
  }

  loadData(pageIndex: number, pageSize: number, sortProperty: string, sortDirection: string) {
    // timer(2000).pipe(
    //   takeUntil(
    //     this.dataService
    //     .query(pageIndex, pageSize, sortProperty, sortDirection)
    //     .pipe(
    //       delay(5000),
    //       catchError(() => of([])),
    //       finalize(() => this.loadingSubject.next(false))
    //     )
    //     .subscribe(response => {
    //       this.queryResponseSubject.next(response);
    //       this.loadingSubject.next(false);
    //     })
    //   ),
    //   // finalize(() => this.loadingSubject.next(true))
    // ).subscribe(() => {
    //   this.loadingSubject.next(true);
    // });
    const dataObservable$ = this.dataService
      .query(pageIndex, pageSize, sortProperty, sortDirection)
      .pipe
      // delay(2000),
      ();

    dataObservable$.subscribe(response => {
      this.queryResponseSubject.next(response);
      this.loadingSubject.next(false);
    });

    timer(600)
      .pipe(takeUntil(dataObservable$))
      .subscribe(x => this.loadingSubject.next(true));

    // this.loadingSubject.next(true);
    // this.dataService
    //   .query(pageIndex, pageSize, sortProperty, sortDirection)
    //   .pipe(
    //     // delay(1200),
    //     catchError(() => of([])),
    //     finalize(() => this.loadingSubject.next(false))
    //   )
    //   .subscribe(response => this.queryResponseSubject.next(response));
  }
}
