import {Component} from '@angular/core';
import {NavigationService} from "../../services/navigation.service";

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss'],
  providers: [NavigationService]
})
export class MainMenuComponent {

  constructor(
    public navigationService: NavigationService) {
  }
}
