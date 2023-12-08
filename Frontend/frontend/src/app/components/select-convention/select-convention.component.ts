import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {LocalCacheService} from "../../services/local-cache.service";
import {Navigation, Router} from "@angular/router";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";
import {ConventionDto, ConventionService} from "../../services/generated-api/conventions";
import {NavigationService} from "../../services/navigation.service";

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
    private router : Router,
    private navigationService : NavigationService
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
  }

  async selectConvention(conventionId : string){
    this.localCacheService.selectedConvention = conventionId;
    await this.navigationService.toConvention(conventionId)
  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;
}
