import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class ServerService {
  private apiUrl = 'https://api.example.com/data';

  constructor(private httpClient: HttpClient) { }

  getAddress(address: string): Observable<Address> {
    return this.httpClient.get<Address>('https://localhost:7045/api/StandardAddress?rawAddress=' + address);
  }
}
