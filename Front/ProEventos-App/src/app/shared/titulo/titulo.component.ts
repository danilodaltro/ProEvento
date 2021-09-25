import { Router, RouterModule } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo = "";
  @Input() subtitulo = "Desde 2021";
  @Input() iconClass = "fa fa-user";
  @Input() botaoListar = false;
  @Input() bgColor = "secondary";

  constructor(private router: Router) { }

  ngOnInit() {
  }

  listar(): void{
    this.router.navigate([`${this.titulo.toLowerCase()}/lista`]);
  }

}
