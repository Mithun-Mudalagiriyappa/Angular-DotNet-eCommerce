import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'SkiNet';
  products: any[];

  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {
    this.httpClient.get('https://localhost:7238/api/Products?pageSize=50')
      .subscribe((response: any) => {
        this.products = response.data;
      }, error => {
        console.log(error);
      })
  }
}
