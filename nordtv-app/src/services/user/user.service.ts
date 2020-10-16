import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProviderService } from '../provider/provider.service';


@Injectable()
export class UserService extends ProviderService{

  private http: HttpClient;

  constructor(_http: HttpClient) {
      super('user');
      this.http = _http;
  }

  public getUsers(): Observable<any>
  {
     return this.http.get<any>(`${this.url}`)
  }

  public getUsersById(id: number): Observable<any>
  {
     return this.http.get<any>(`${this.url}/${id}`);
  }

  public InsertUser(data: any): Observable<any>
  {
     return this.http.post(`${this.url}`, data, {});
  }

}
