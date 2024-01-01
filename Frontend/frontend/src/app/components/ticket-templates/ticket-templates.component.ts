import {Component, ViewChild} from '@angular/core';
import {Observable} from "rxjs";
import {
  TicketDto,
  TicketService,
  TicketTemplateDto,
  TicketTemplateService
} from "../../services/generated-api/conventions";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {ActivatedRoute} from "@angular/router";
import {SubdomainService} from "../../services/subdomain.service";
import {NavigationService} from "../../services/navigation.service";
import {getFriendlyErrorMessage} from 'src/app/utilities/errorUtilities';

@Component({
  selector: 'app-ticket-templates',
  templateUrl: './ticket-templates.component.html',
  styleUrls: ['./ticket-templates.component.scss']
})
export class TicketTemplatesComponent {
  private conventionId!: string;

  tickets$!: Observable<Array<TicketTemplateDto>>;

  displayedColumns: string[] = ['id', 'name', 'available'];
  dataSource = new MatTableDataSource<TicketTemplateDto>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private route: ActivatedRoute,
    private ticketTemplateService: TicketTemplateService,
    private subdomainService: SubdomainService,
    private navigationService: NavigationService
  ) {
  }

  ngOnInit()
    :
    void {
    this.route.params.subscribe(params => {
      this.conventionId = params['conventionId'];
      this.tickets$ = this.ticketTemplateService.apiConventionsConventionIdTicketTemplatesGet(this.conventionId);
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
    await this.navigationService.toTicketTemplateDetails(row.id);
  }

  navigateToCreateTicketTemplate() {

  }
}
