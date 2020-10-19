import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  private _baseUrl = environment.urlFlights;

  constructor(private _httpClient: HttpClient) {}

  filterFlights(searchString: string): Observable<any> {
    const url = this._baseUrl + `/Passagem/buscar/local/${searchString}`;
    return this._httpClient.get(url);
  }

  searchFlights(
    fromPlace: string,
    toPlace: string,
    departDate: string,
    returnDate: string
  ): Observable<any> {
    const url =
      this._baseUrl +
      `/Passagem/buscar/voos/${fromPlace}/${toPlace}/${departDate}/${returnDate}`;
    return this._httpClient.get(url);
  }
}
