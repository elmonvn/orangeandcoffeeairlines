export interface CompraItem {
  id: number;
  compraId: number;
  empresaId: number;
  empresa: string;
  origemId: number;
  origem: string;
  destinoId: number;
  destino: string;
  preco: number;
  dtSaida: string;
  dtChegada: string;
}
