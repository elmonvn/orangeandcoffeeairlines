import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenApp } from '../models/authentication/token-app';
import { Research } from '../models/authentication/research';
import { RegisterApp } from '../models/authentication/register-app';
import { Revoke } from '../models/authentication/revoke';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _baseUrl = environment.urlAuth;

  constructor(private _httpClient: HttpClient) {}

  generateToken(token: TokenApp): Observable<any> {
    const url = this._baseUrl + '/api/Authentication/Token';
    return this._httpClient.post(url, token);
  }

  queryProfile(token: Research): Observable<any> {
    const url = this._baseUrl + '/Authentication/Consultar';
    return this._httpClient.post(url, token);
  }

  registerApi(token: RegisterApp): Observable<any> {
    const url = this._baseUrl + '/Authentication/Registrar';
    return this._httpClient.post(url, token);
  }

  revokeApi(token: Revoke): Observable<any> {
    const url = this._baseUrl + '/Authentication/Revogar';
    return this._httpClient.request('delete', url, { body: token });
  }
}
