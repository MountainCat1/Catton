import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Observable} from "rxjs";
import {
  AttendeeDto,
  AttendeeService,
  TicketTemplateService
} from "../../services/generated-api/conventions";
import {ActivatedRoute} from "@angular/router";
import {NavigationService} from "../../services/navigation.service";
import {getFriendlyErrorMessage} from "../../utilities/errorUtilities";
import {MatTableDataSource, MatTableModule} from "@angular/material/table";
import {MatPaginator, MatPaginatorModule} from "@angular/material/paginator";

@Component({
  selector: 'app-attendees',
  templateUrl: './attendees.component.html',
  styleUrls: ['./attendees.component.scss']
})
export class AttendeesComponent implements OnInit, AfterViewInit  {
  private conventionId! : string;

  attendees$!: Observable<Array<AttendeeDto>>;

  displayedColumns: string[] = ['username', 'id', 'createdDate', 'avatarUri'];
  dataSource = new MatTableDataSource<AttendeeDto>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private route: ActivatedRoute,
    private attendeeService : AttendeeService,
  ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.attendees$ = this.attendeeService.apiConventionsConventionIdAttendeesGet(this.conventionId);
      this.attendees$.subscribe(attendees => {
        this.dataSource.data = attendees

      })
    });

  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
}
