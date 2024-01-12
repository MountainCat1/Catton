import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AttendeeDto, OrganizerDto, OrganizerService} from "../../services/generated-api/conventions";
import {Observable} from "rxjs";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";
import {NavigationService} from "../../services/navigation.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-organizers',
  templateUrl: './organizers.component.html',
  styleUrls: ['./organizers.component.scss'],
  providers: [NavigationService]
})
export class OrganizersComponent implements OnInit, AfterViewInit {
  private conventionId! : string;
  organizers$!: Observable<Array<OrganizerDto>>;

  displayedColumns: string[] = ['username', 'id', 'createdDate', 'accountId', 'avatarUri'];
  dataSource = new MatTableDataSource<OrganizerDto>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(
    private route: ActivatedRoute,
    private organizerService : OrganizerService,
    private navigationService : NavigationService
    ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.organizers$ = this.organizerService.apiConventionsConventionIdOrganizersGet(this.conventionId);
      this.organizers$.subscribe(organizers => {
        this.dataSource.data = organizers;
      })
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;

  async onRowClicked(row : any) {
    await this.navigationService.toOrganizerDetails(row.accountId);
  }

  async navigateToCreateOrganizer() {
    await this.navigationService.toCreateOrganizer();
  }
}
