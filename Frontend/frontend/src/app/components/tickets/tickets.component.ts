import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Observable} from "rxjs";
import {AttendeeDto, AttendeeService, TicketDto, TicketService} from "../../services/generated-api/conventions";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {ActivatedRoute} from "@angular/router";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import { getFriendlyErrorMessage } from 'src/app/utilities/errorUtilities';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss']
})
export class TicketsComponent implements OnInit, AfterViewInit {
  private conventionId!: string;

  tickets$!: Observable<Array<TicketDto>>;

  displayedColumns: string[] = ['id', 'ticketTemplateName', 'createdDate'];
  dataSource = new MatTableDataSource<TicketDto>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private route: ActivatedRoute,
    private ticketService: TicketService,
    private subdomainService: SubdomainService,
    private navigationService: NavigationService
  ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.tickets$ = this.ticketService.apiConventionsConventionIdTicketsGet(this.conventionId);
      this.tickets$.subscribe(tickets => {
        this.dataSource.data = tickets
      })
    });
  }

  protected readonly getFriendlyErrorMessage = getFriendlyErrorMessage;

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;

    if (this.sort == undefined)
      console.error("Sort is undefined!")
    this.dataSource.sort = this.sort!;
  }

  async onRowClicked(row: any) {
    await this.navigationService.toTicketDetails(row.id);
  }
}
