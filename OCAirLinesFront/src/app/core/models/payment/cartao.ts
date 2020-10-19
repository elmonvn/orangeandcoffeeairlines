import { CompraItem } from './compra-item';

export interface Cartao {
  cartaoId: number;
  usuarioId: number;
  qtdParcela: number;
  itens: CompraItem[];
}
