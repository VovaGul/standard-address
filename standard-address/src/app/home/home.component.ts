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

  constructor(private serverService: ServerService) { }

  send(): void {
    this.serverService.getAddress().subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.error('Error fetching data:', error);
      }
    );
  }
}
