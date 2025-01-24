import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private myAppURL = "https://localhost:44340/";
  private myApiURL = "api/Contacto/" 

  constructor(private http: HttpClient) { }

  GuardarContacto(contacto: any): Observable<any> {
    return this.http.post(this.myAppURL + this.myApiURL, contacto);
  }
}
