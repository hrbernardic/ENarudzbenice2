import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable, BehaviorSubject, of, timer } from 'rxjs';
import { finalize, catchError, delay, map, takeUntil, tap, publishLast, refCount } from 'rxjs/operators';
import { TableQueryRequest } from '../enarudzbenice2-api';

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

  loadData(queryRequest: TableQueryRequest) {
    const dataObservable$ = this.dataService
      .query(queryRequest)
      .pipe(publishLast())
      .refCount();

    dataObservable$.subscribe(response => {
      this.queryResponseSubject.next(response);
      this.loadingSubject.next(false);
    });

    timer(600)
      .pipe(takeUntil(dataObservable$))
      .subscribe(x => this.loadingSubject.next(true));
  }
}
