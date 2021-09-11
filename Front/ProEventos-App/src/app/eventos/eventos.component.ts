import { EventoService } from './../services/evento.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public exibirImg: boolean = true;
  private _filtroLista: string = "";

  constructor(private eventoService: EventoService) { }

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarExibicaoImagem(): void{
    this.exibirImg = !this.exibirImg;
  }


  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe(
      (evento: Evento[]) =>
      {
        this.eventos = evento;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    )
  }
}
