import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent implements OnInit {

  breadcrumb$:Observable<any[]>;

  constructor(private breadcrumService: BreadcrumbService) { }

  ngOnInit(): void {
    //1) When 'http requests' gets completed, the subscription 
    //   gets 'unsubscribed' automatically.
    //   Ex: shop.component.ts 

    //2) xng-breadcrumb is a third party npm package. 
    //   As a result, we have to unsubscribe.
    //   This is handled in the html page i.e., line: <ng-container *ngIf="(breadcrumb$ | async) as breadcrumbs">
    this.breadcrumb$ = this.breadcrumService.breadcrumbs$;
  }
}
