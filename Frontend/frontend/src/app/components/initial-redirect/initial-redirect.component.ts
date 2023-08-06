import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-initial-redirect',
  templateUrl: './initial-redirect.component.html',
  styleUrls: ['./initial-redirect.component.scss']
})
export class InitialRedirectComponent implements OnInit{
  constructor(
    private authService : AuthService,
    private navigationService : NavigationService,

  ) {
    authService.tryGetAccount().subscribe(async x => {
      if(x == undefined){
        await navigationService.toSignIn();
      }
      await navigationService.toSelectConvention()
    })
  }


  ngOnInit(): void {


  }



}
