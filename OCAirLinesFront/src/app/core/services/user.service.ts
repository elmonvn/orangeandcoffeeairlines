import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Cartao } from '../models/webapi/cartao';
import { Compra } from '../models/webapi/compra';
import { CompraItem } from '../models/webapi/compra-item';
import { Favorita } from '../models/webapi/favorita';
import { Pesquisa } from '../models/webapi/pesquisa';
import { Usuario } from '../models/webapi/usuario';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _baseUrl = environment.urlWebApi;

  constructor(private _httpClient: HttpClient) {}

  // TODO cartaoId não existe no modelo
  getCartaoByCartaoId(cartaoId: number): Observable<any> {
    const url = this._baseUrl + `/Cartao/${cartaoId}`;
    return this._httpClient.get(url);
  }

  getAllCartoesByUsuarioId(usuarioId: number): Observable<any> {
    const url = this._baseUrl + `/Cartao/${usuarioId}`;
    return this._httpClient.get(url);
  }

  // TODO cartaoId não existe no modelo
  updateCartao(cartao: Cartao): Observable<any> {
    const url = this._baseUrl + `/Cartao/${cartao.id}`;
    return this._httpClient.put(url, cartao);
  }

  // TODO cartaoId não existe no modelo
  deleteCartao(cartaoId: number): Observable<any> {
    const url = this._baseUrl + `/Cartao/${cartaoId}`;
    return this._httpClient.delete(url);
  }

  createCartao(cartao: Cartao): Observable<any> {
    const url = this._baseUrl + `/Cartao`;
    return this._httpClient.post(url, cartao);
  }

  getAllCompras(): Observable<any> {
    const url = this._baseUrl + `/Compra`;
    return this._httpClient.get(url);
  }

  // TODO compraId não existe no modelo
  getCompra(compraId: number): Observable<any> {
    const url = this._baseUrl + `/Compra/${compraId}`;
    return this._httpClient.get(url);
  }

  createCompra(compra: Compra): Observable<any> {
    const url = this._baseUrl + `/Compra`;
    return this._httpClient.post(url, compra);
  }

  // TODO compraId não existe no modelo
  updateCompra(compra: Compra): Observable<any> {
    const url = this._baseUrl + `/Compra/${compra.id}`;
    return this._httpClient.put(url, compra);
  }

  // TODO compraId não existe no modelo
  deleteCompra(compraId: number): Observable<any> {
    const url = this._baseUrl + `/Compra/${compraId}`;
    return this._httpClient.delete(url);
  }

  getAllCompraItemsByCompraId(compraId: number): Observable<any> {
    const url = this._baseUrl + `/CompraItem/${compraId}`;
    return this._httpClient.get(url);
  }

  getCompraItem(compraItemId: number): Observable<any> {
    const url = this._baseUrl + `/CompraItem/${compraItemId}`;
    return this._httpClient.get(url);
  }

  updateCompraItem(compraItem: CompraItem): Observable<any> {
    const url = this._baseUrl + `/CompraItem/${compraItem.id}`;
    return this._httpClient.put(url, compraItem);
  }

  deleteCompraItem(compraItemId: number): Observable<any> {
    const url = this._baseUrl + `/CompraItem/${compraItemId}`;
    return this._httpClient.delete(url);
  }

  createCompraItem(compraItem: CompraItem): Observable<any> {
    const url = this._baseUrl + `/CompraItem`;
    return this._httpClient.post(url, compraItem);
  }

  getAllFavoritasByUsuarioId(usuarioId: number): Observable<any> {
    const url = this._baseUrl + `/Favorita/${usuarioId}`;
    return this._httpClient.get(url);
  }

  getFavorita(favoritaId: number): Observable<any> {
    const url = this._baseUrl + `/Favorita/${favoritaId}`;
    return this._httpClient.get(url);
  }

  updateFavorita(favorita: Favorita): Observable<any> {
    const url = this._baseUrl + `/Favorita/${favorita.id}`;
    return this._httpClient.put(url, favorita);
  }

  deleteFavorita(favoritaId: number): Observable<any> {
    const url = this._baseUrl + `/Favorita/${favoritaId}`;
    return this._httpClient.delete(url);
  }

  createFavorita(favorita: Favorita): Observable<any> {
    const url = this._baseUrl + `/Favorita`;
    return this._httpClient.post(url, favorita);
  }

  getAllPesquisasByUsuarioId(usuarioId: number): Observable<any> {
    const url = this._baseUrl + `/Pesquisa/${usuarioId}`;
    return this._httpClient.get(url);
  }

  getPesquisa(pesquisaId: number): Observable<any> {
    const url = this._baseUrl + `/Pesquisa/${pesquisaId}`;
    return this._httpClient.get(url);
  }

  updatePesquisa(pesquisa: Pesquisa): Observable<any> {
    const url = this._baseUrl + `/Pesquisa/${pesquisa.id}`;
    return this._httpClient.put(url, pesquisa);
  }

  deletePesquisa(pesquisaId: number): Observable<any> {
    const url = this._baseUrl + `/Pesquisa/${pesquisaId}`;
    return this._httpClient.get(url);
  }

  createPesquisa(pesquisa: Pesquisa): Observable<any> {
    const url = this._baseUrl + `/Pesquisa/${pesquisa.id}`;
    return this._httpClient.post(url, pesquisa);
  }

  getAllUsuarios(): Observable<any> {
    const url = this._baseUrl + `/Usuario`;
    return this._httpClient.get(url);
  }

  getUsuario(usuarioId: number): Observable<any> {
    const url = this._baseUrl + `/Usuario/${usuarioId}`;
    return this._httpClient.get(url);
  }

  updateUsuario(usuario: Usuario): Observable<any> {
    const url = this._baseUrl + `/Usuario/${usuario.id}`;
    return this._httpClient.put(url, usuario);
  }

  deleteUsuario(usuarioId: number): Observable<any> {
    const url = this._baseUrl + `/Usuario/${usuarioId}`;
    return this._httpClient.delete(url);
  }

  createUsuario(usuario: Usuario): Observable<any> {
    const url = this._baseUrl + `/Usuario`;
    return this._httpClient.post(url, usuario);
  }
}
