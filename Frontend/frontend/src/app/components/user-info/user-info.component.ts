import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {Observable} from "rxjs";
import {AccountDto} from "../../services/generated-api/accounts";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {

  account$! : Observable<AccountDto>;

  constructor(private authService : AuthService) {
  }

  ngOnInit(): void {
    this.account$ = this.authService.getAccount()
  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;
}
