export interface Pesquisa {
  id: number;
  usuarioId: number;
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
