import { Injectable } from '@angular/core';
import {LocalStorageService} from "angular-web-storage";

export interface ApplicationLocalCache {
  selectedConvention : string | null,
  selectedUser : string | null,
}

@Injectable({
  providedIn: 'root'
})
export class LocalCacheService {
  private readonly localCacheKey: string = 'ConventowoLocalCache';
  private readonly cachedData: ApplicationLocalCache;

  constructor(private localStorage: LocalStorageService) {
    this.cachedData = this.loadDataFromCache();
  }

  private initializeCachedData() : ApplicationLocalCache {
    return {
      selectedConvention: null,
      selectedUser: null,
    }
  }

  private loadDataFromCache(): ApplicationLocalCache {
    const cachedData = this.localStorage.get(this.localCacheKey);
    return cachedData ? cachedData : this.initializeCachedData();
  }

  private saveDataToCache(data: ApplicationLocalCache): void {
    this.localStorage.set(this.localCacheKey, data);
  }

  get selectedConvention(): string | null {
    return this.cachedData.selectedConvention;
  }

  set selectedConvention(convention: string | null) {
    this.cachedData.selectedConvention = convention;
    this.saveDataToCache(this.cachedData);
  }
}
