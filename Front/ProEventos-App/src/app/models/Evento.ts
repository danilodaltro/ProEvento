import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  id: number;
  tema: string;
  local: string;
  qtdPessoas: number;
  dataEvento?: Date;
  imagemURL: string;
  telefone: string;
  email: string;
  lotes: Lote[];
  palestranteEvento: Palestrante[];
  redesSociais: RedeSocial[];
}
