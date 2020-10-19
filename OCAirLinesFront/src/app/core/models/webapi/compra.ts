export interface Compra {
  id: number;
  usuarioId: number;
  cartaoId: number;
  dtCompra: string;
  qtdParcela: number;
  status: boolean;
}
