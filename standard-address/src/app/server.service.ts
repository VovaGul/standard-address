import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Address } from './address.model';
import { EnvironmentService } from 'src/environments/environment.service';

@Injectable({
  providedIn: 'root'
})
export class ServerService {
  private apiUrl = 'https://api.example.com/data';

  constructor(private httpClient: HttpClient,
    private environmentService: EnvironmentService) { }

  getAddress(address: string): Observable<Address> {
    return this.httpClient.get<Address>(this.environmentService.getValue('apiUrl') + 'StandardAddress?rawAddress=' + address);
  }
}
