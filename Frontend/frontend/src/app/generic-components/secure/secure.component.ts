import {Component, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {NavigationService} from "../../services/navigation.service";
import {ActivatedRoute, ActivationEnd, Router} from "@angular/router";
import {logMessages} from "@angular-devkit/build-angular/src/builders/browser-esbuild/esbuild";
import {filter} from "rxjs";
import {map} from "rxjs/operators";

@Component({
  selector: 'app-secure',
  templateUrl: './secure.component.html',
  styleUrls: ['./secure.component.scss'],
  providers: [NavigationService]
})
export class SecureComponent {
  @ViewChild('leftSidenav') leftSidenav!: MatSidenav;
  @ViewChild('rightSidenav') rightSidenav!: MatSidenav;

  constructor(
    public navigationService: NavigationService,
    private activatedRoute: ActivatedRoute) {
  }


  hideSidebars() {
    this.leftSidenav.toggle(false).then();
    this.rightSidenav.toggle(false).then();
  }

  // Function to toggle the left sidenav
  async toggleLeftSidenav() {
    await this.leftSidenav.toggle();
  }

  // Function to toggle the right sidenav
  async toggleRightSidenav() {
    await this.rightSidenav.toggle().then();
  }


}
