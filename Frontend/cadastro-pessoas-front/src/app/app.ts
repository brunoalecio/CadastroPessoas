import { Component } from '@angular/core';
import { CadastroComponent } from './cadastro/cadastro';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CadastroComponent],
  template: `<app-cadastro></app-cadastro>`
})
export class App {}