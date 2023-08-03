import {Component, OnInit} from '@angular/core';
import {NgIf} from "@angular/common";
import {Observable} from "rxjs";
import {StaticChipType} from "../../generic-components/static-chip/static-chip.component";
import {LocalCacheService} from "../../services/local-cache.service";
import {Navigation, Router} from "@angular/router";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";
import {ConventionDto, ConventionService} from "../../services/generated-api/conventions";

@Component({
  selector: 'app-select-convention',
  templateUrl: './select-convention.component.html',
  styleUrls: ['./select-convention.component.scss']
})
export class SelectConventionComponent implements OnInit {
  conventions$!: Observable<Array<ConventionDto>>;


  constructor(
    private conventionService : ConventionService,
    private localCacheService : LocalCacheService,
    private router : Router
  ) {
  }

  ngOnInit(): void {
    this.conventions$ = this.conventionService.apiConventionsGet();

    // If user has access to only one convention redirect them instantly to menu
    // if they have no choice why do would we pretend they have XD
    this.conventions$.subscribe(x => {
      if(x.length === 1){
        this.router.navigate(['/']).then();
      }
    });

    this.conventions$.subscribe(x => console.log(x))
  }

  selectConvention(conventionId : string){
    this.localCacheService.selectedConvention = conventionId;
    this.router.navigate(['/']).then()
  }

  protected readonly String = String;
  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;
}
