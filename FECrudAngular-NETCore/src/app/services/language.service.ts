import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private baseUrl = "https://localhost:44340/api/Traduccion";

  constructor(private http: HttpClient) {}

  getLanguageLabels(lang: string): Observable<any> {
    const url = `${this.baseUrl}?lang=${lang}`;
    return this.http.get(url);
  }
}
