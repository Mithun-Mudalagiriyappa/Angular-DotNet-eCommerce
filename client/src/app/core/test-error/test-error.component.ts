import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseURL = environment.baseUrl;
  validationErrors: any;

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.httpClient.get(this.baseURL + 'products/42').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get500Error() {
    this.httpClient.get(this.baseURL + 'buggy/GetServerError').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400Error() {
    this.httpClient.get(this.baseURL + 'buggy/getbadrequest').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

   get400ValidationError() {
    this.httpClient.get(this.baseURL + 'buggy/badrequest/fortytwo').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }
}
