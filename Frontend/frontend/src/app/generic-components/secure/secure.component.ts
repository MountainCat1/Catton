import {Component, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {Router} from "@angular/router";

@Component({
  selector: 'app-secure',
  templateUrl: './secure.component.html',
  styleUrls: ['./secure.component.scss']
})
export class SecureComponent {
  @ViewChild('leftSidenav') leftSidenav!: MatSidenav;
  @ViewChild('rightSidenav') rightSidenav!: MatSidenav;

  constructor(private router : Router) {

  }


  navigateToFromSidebar(path : string){
    this.router.navigate([path])
    this.leftSidenav.toggle(false)
    this.rightSidenav.toggle(false)
  }

  // Function to toggle the left sidenav
  toggleLeftSidenav() {
    this.leftSidenav.toggle();
  }
  // Function to toggle the right sidenav
  toggleRightSidenav() {
    this.rightSidenav.toggle();
  }


}
