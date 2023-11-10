import {Inject, Injectable} from '@angular/core';
import {DOCUMENT} from "@angular/common";

@Injectable({
  providedIn: 'root'
})
export class SubdomainService {
  constructor(@Inject(DOCUMENT) private document: Document) {}

  getSubdomain(): string {
    const hostname = this.document.location.hostname;
    const parts = hostname.split('.');
    // Check if the hostname has at least two parts (e.g., "subdomain.example.com")
    if (parts.length >= 2) {
      // Return the first part as the subdomain
      return parts[0];
    } else {
      // No subdomain found (e.g., "example.com")
      return '';
    }
  }
}
