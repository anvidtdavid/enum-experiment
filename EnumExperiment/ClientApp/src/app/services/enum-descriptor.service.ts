import { Injectable, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EnumDisplayInfo } from '../models';

@Injectable({
  providedIn: 'root'
})
export class EnumDescriptorService implements OnDestroy {

  public isDestroyed$ = new Subject<boolean>();

  private $enuCache: any;

  constructor(private http: HttpClient) {

    const f = this.ngOnDestroy.bind(this);
    this.ngOnDestroy = () => {
      this.isDestroyed$.next(true);
      this.isDestroyed$.complete();
      f();
    };

    http.get<any>('/api/common/getenums').pipe(takeUntil(this.isDestroyed$)).subscribe(x => {
      console.log(x);
      localStorage.setItem('codeValues', JSON.stringify(x));
    });
  }

  getValue(type: string, value: any, dx: boolean = false, language?: string): string {

    if (!this.$enuCache) {
      this.$enuCache = JSON.parse(localStorage.getItem('codeValues'));
    }

    if (!language) {
      language = 'en-IN';
    }

    if (this.$enuCache.hasOwnProperty(type)) {
      if (this.$enuCache[type].hasOwnProperty(value)) {
        if (this.$enuCache[type][value]['displayInfo'].hasOwnProperty(language)) {
          const displayInfo: EnumDisplayInfo = this.$enuCache[type][value]['displayInfo'][language];
          if (displayInfo) {
            if (dx) {
              return displayInfo.description;
            } else {
              return displayInfo.display;
            }
          }
        }
      }
    }

    return `${type}.${value}`;
  }

  ngOnDestroy(): void { }
}
