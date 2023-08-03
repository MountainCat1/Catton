import { Component } from '@angular/core';
import {Router} from "@angular/router";
import {LocalCacheService} from "../../services/local-cache.service";

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent {

  constructor(
    private router : Router,
    private localCacheService : LocalCacheService) {

  }


  navigateTo(path: string) {
    const conventionId = this.localCacheService.selectedConvention;
    this.router.navigate([`/${conventionId}`, path])
  }
}
