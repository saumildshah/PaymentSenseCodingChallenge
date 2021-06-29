import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CountryModel } from '../models/country.model';
import { environment } from '../../environments/environment';
import { catchError, map } from 'rxjs/operators';
import { RouteConstants } from '../constants/route-constants';
import { throwError } from 'rxjs/internal/observable/throwError';

@Injectable({
  providedIn: 'root'
})
export class CountryApiService {
  private baseUrl: string = environment.baseUrl;
  constructor(private httpClient: HttpClient) { }

  public getCountries(): Observable<CountryModel[]> {

    let url: string = this.baseUrl + RouteConstants.countries;
    return this.httpClient.get<any>(url)
      .pipe(map(response =>
        response.response as CountryModel[]), catchError(error => {
          return throwError('Something went wrong!');
        }));   
  }

}
