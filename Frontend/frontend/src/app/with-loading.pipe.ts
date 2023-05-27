import { Pipe, PipeTransform } from '@angular/core';
import {isObservable, Observable, of} from 'rxjs';
import { map, startWith, catchError } from 'rxjs/operators';

@Pipe({
  name: 'withLoading',
})
export class WithLoadingPipe implements PipeTransform {
  transform(val: Observable<any>) {
    return isObservable(val)
      ? val.pipe(
        map((value: any) => ({ loading: false, value, error: null })),
        startWith({ loading: true, value: null, error: null }),
        catchError(error => of({ loading: false, error, value: null }))
      )
      : val;
  }
}
