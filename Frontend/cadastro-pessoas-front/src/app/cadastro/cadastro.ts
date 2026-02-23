import { ChangeDetectorRef } from '@angular/core'; // 1. Adicione a importação
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PessoaService } from '../services/pessoa';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cadastro.html',
  styleUrl: './cadastro.css'
})
export class CadastroComponent {

  nome = '';
  cpf = '';
  cep = '';

  endereco: any = null;
  mensagem = '';

  carregandoCep = false;
  podeCadastrar = false;
  bloqueado = false;

  constructor(
    private pessoaService: PessoaService,
    private cdr: ChangeDetectorRef // 2. Injete aqui
  ) {}

  consultarCep() {
  this.cep = this.cep.replace(/\D/g, ''); // Garante que só tem números
  
  if (this.cep.length !== 8 || this.bloqueado) return;

  this.carregandoCep = true;
  this.endereco = null;
  this.podeCadastrar = false;

  this.pessoaService.consultarCep(this.cep).subscribe({
    next: (data: any) => {
      console.log("Passou no next!", data);
      
      if (data.erro) {
        alert("CEP não encontrado!");
        this.carregandoCep = false;
        this.cdr.detectChanges(); // Força a tela a atualizar
        return;
      }

      this.endereco = data;
      this.podeCadastrar = true;
      this.carregandoCep = false;
      this.cdr.detectChanges(); // Força a tela a atualizar
    },
    error: (err) => {
      console.log("Erro na chamada:", err);
      this.carregandoCep = false;
      this.cdr.detectChanges(); // Força a tela a atualizar
    }
  });
}

  cadastrar() {
    if (!this.podeCadastrar || this.bloqueado) return;

    const pessoa = {
      nome: this.nome,
      cpf: this.cpf,
      cep: this.cep
    };

    this.bloqueado = true;

    this.pessoaService.criarPessoa(pessoa).subscribe({
      next: () => {
        // Exibe o feedback visual
        this.mensagem = 'Cadastro realizado com sucesso!';

        // Limpa os campos do formulário
        this.nome = '';
        this.cpf = '';
        this.cep = '';
        this.endereco = null;
        this.podeCadastrar = false;

        // 1. Força a tela a atualizar para mostrar a mensagem e limpar os inputs
        this.cdr.detectChanges(); 

        // Remove a mensagem e libera o botão após 3 segundos
        setTimeout(() => {
          this.bloqueado = false;
          this.mensagem = '';
          
          // 2. Força a tela a atualizar de novo para sumir a caixa verde
          this.cdr.detectChanges(); 
        }, 3000);
      },
      error: () => {
        this.mensagem = 'Erro ao cadastrar.';
        this.bloqueado = false;
        this.cdr.detectChanges(); // 3. Força a tela a atualizar em caso de erro
      }
    });
  }
}