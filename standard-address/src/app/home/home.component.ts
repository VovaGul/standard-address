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
  address: string = '';

  constructor(private serverService: ServerService) { }

  send(): void {
    this.serverService.getAddress(this.rowAddress).subscribe(
      data => {
        this.address = data.result
      },
      error => {
        console.error('Error fetching data:', error);
      }
    );
  }
}
