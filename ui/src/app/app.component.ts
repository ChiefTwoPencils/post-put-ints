import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, ObservableInput, Subscriber, throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'put-posts';
  result = "";
  data = [[1,2],[3,4],[5,6]];

  constructor(private _http: HttpClient) {}

  put() {
    this._http.put<string>("http://localhost:5041/ints", this.data, {})
      .pipe(catchError(this.handleError))
      .subscribe(r => this.showResult(r))      
  }

  post() {
    this._http.post<string>("http://localhost:5041/ints", this.data, {})
    .pipe(catchError(this.handleError))
    .subscribe(r => this.showResult(r))
  }

  oops() {
    this._http.post<string>("http://localhost:5041/ints/" + this.data, {})
    .pipe(catchError(this.handleError))
    .subscribe(r => this.showResult(r))
  }

  showResult(r: string) {
    this.result = r;
  }

  handleError(error: HttpErrorResponse): Observable<string> {
    const result: string = error.status + " - " + error.statusText;
    return new Observable<string>((sub: Subscriber<string>) => sub.next(result));
  }
}
