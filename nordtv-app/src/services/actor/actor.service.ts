import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProviderService } from '../provider/provider.service';

@Injectable()
export class ActorService extends ProviderService{

  private http: HttpClient;

  constructor(_http: HttpClient) {
      super('actor');
      this.http = _http;
  }

  public getActors(): Observable<any>
  {
     return this.http.get<any>(`${this.url}`)
  }

  public getActorsById(id: number): Observable<any>
  {
     return this.http.get<any>(`${this.url}/${id}`);
  }

  public InsertActor(data: any): Observable<any>
  {
     return this.http.post(`${this.url}`, data, {});
  }
}