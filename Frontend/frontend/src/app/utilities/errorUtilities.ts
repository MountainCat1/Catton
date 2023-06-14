import {HttpErrorResponse} from "@angular/common/http";

export function getFriendlyErrorMessage(error : HttpErrorResponse) : string {
  return error.statusText
}
