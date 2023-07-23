import { Pipe, PipeTransform } from '@angular/core';
import {isObservable, Observable, of} from 'rxjs';
import { map, startWith, catchError } from 'rxjs/operators';
import {HttpErrorResponse} from "@angular/common/http";

interface Loadable<T> {
  loading: boolean;
  value: T | null;
  error: HttpErrorResponse | null;
}

@Pipe({
  name: 'withHttpLoading',
})
export class WithHttpLoadingPipe implements PipeTransform {
  transform<T>(val: Observable<T>): Observable<Loadable<T>> {
    return isObservable(val)
      ? val.pipe(
        map((value: T) => ({ loading: false, value, error: null })),
        startWith({ loading: true, value: null, error: null }),
        catchError(error => of({ loading: false, error: error as HttpErrorResponse, value: null }))
      )
      : of({ loading: false, value: val as T, error: null });
  }
}
