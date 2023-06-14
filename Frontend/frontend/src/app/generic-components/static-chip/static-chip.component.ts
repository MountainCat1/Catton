import {Component, Input, OnInit} from '@angular/core';
import {ThemePalette} from "@angular/material/core";

export type StaticChipType = 'active' | 'pending' | 'stopped';

@Component({
  selector: 'app-static-chip',
  template: `
    <span class="static-chip" [ngClass]="getColorClass()">
      <ng-content></ng-content>
    </span>
  `,
  styleUrls: ['./static-chip.component.scss']
})
export class StaticChipComponent implements OnInit{
  @Input() chipType!: StaticChipType;

  ngOnInit(): void {

  }

  getColorClass(): string {
    switch (this.chipType) {
      case "active":
        return 'active-static-chip';
      case "pending":
        return 'pending-static-chip';
      case "stopped":
        return 'stopped-static-chip';
      default:
        return '';
    }
  }
}
