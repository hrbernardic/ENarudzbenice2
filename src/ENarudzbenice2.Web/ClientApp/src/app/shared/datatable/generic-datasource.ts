import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { finalize, catchError, delay } from 'rxjs/operators';

export class GenericDatasource extends DataSource<any> {
  private dataSubject = new BehaviorSubject<any[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  // tslint:disable-next-line:member-ordering
  public loading$ = this.loadingSubject.asObservable();

  constructor(private dataService: any, private paginator: MatPaginator, private sort: MatSort) {
    super();
  }

  connect(collectionViewer: CollectionViewer): Observable<any[]> {
    return this.dataSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.dataSubject.complete();
    this.loadingSubject.complete();
  }

  loadData() {
    this.loadingSubject.next(true);
    this.dataService
      .getAll()
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
      .subscribe(data => this.dataSubject.next(data));
  }
}
