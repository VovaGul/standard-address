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

  getAddress(): Observable<Address> {
    return this.httpClient.get<Address>('https://localhost:7045/api/StandardAddress?rawAddress=%D0%BC%D1%81%D0%BA%20%D1%81%D1%83%D1%85%D0%BE%D0%BD%D1%81%D0%BA%D0%B0%2011%2F-89');
  }
}
