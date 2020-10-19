import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cartao } from '../models/payment/cartao';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private _baseUrl = environment.urlPayment;

  constructor(private _httpClient: HttpClient) {}

  pay(cartao: Cartao): Observable<any> {
    const url = this._baseUrl + '/Cartao/Pagar';
    return this._httpClient.post(url, cartao);
  }

  getPayment(usuarioId: number, compraId: number): Observable<any> {
    const url = this._baseUrl + `/Pagamento/Status/${usuarioId}/${compraId}`;
    return this._httpClient.get(url);
  }
}
