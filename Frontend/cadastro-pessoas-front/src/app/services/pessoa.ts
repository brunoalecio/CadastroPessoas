import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  private apiUrl = 'https://localhost:7232/api/pessoas/fisica';

  constructor(private http: HttpClient) {}

  criarPessoa(pessoa: any) {
    return this.http.post(this.apiUrl, pessoa);
  }

  consultarCep(cep: string) {
    return this.http.get(`https://viacep.com.br/ws/${cep}/json/`);
  }
}