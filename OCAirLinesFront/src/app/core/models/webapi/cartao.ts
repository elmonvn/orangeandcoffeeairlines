export interface Cartao {
  id: number;
  usuarioId: number;
  bandeira: string;
  numero: string;
  codSeguranca: string;
  vencimento: string;
  status: boolean;
}
