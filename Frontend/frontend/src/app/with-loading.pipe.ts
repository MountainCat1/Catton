import { Pipe, PipeTransform } from '@angular/core';
import {isObservable, Observable, of} from 'rxjs';
import { map, startWith, catchError } from 'rxjs/operators';
import {HttpErrorResponse} from "@angular/common/http";

@Pipe({
  name: 'withHttpLoading',
})
export class WithHttpLoadingPipe implements PipeTransform {
  transform(val: Observable<any>) {
    return isObservable(val)
      ? val.pipe(
        map((value: any) => ({ loading: false, value, error: null })),
        startWith({ loading: true, value: null, error: null }),
        catchError(error => of({ loading: false, error: error as HttpErrorResponse, value: null }))
      )
      : val;
  }
}
