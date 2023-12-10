import { Address } from './../address.model';
import { ServerService } from './../server.service';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  rowAddress: string = '';
  result: string = '';

  constructor(private serverService: ServerService) { }

  send(): void {
    this.serverService.getAddress(this.rowAddress).subscribe({
      next: (data) => {
        this.result = data.result ?? "Не удалось стандартизировать адрес. Попробуйте ввести более точное значение"
      },
      error: (error) => {
        console.error('Error fetching data:', error);
        this.result = "Внутренняя ошибка, попробуйте перезагрузить страницу или повторить запрос позже"
      }
   });
  }
}
