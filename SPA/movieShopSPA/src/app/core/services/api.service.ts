import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders, HttpParams} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import {map} from 'rxjs/operators'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private headers: HttpHeaders;
  constructor(protected http:HttpClient) { 
    this.headers = new HttpHeaders();
    this.headers.append('Content-type','application/json');
    this.headers.append('Access-Control-Allow-Origin','*');
  }


  getAll(path:string, id?:number) : Observable<any[]>{
    if(id){
      return this.http.get(`${environment.apiUrl}${path}`+`/`+ id).pipe(
        map(res => res as any[]));
    }
    else{
    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map(res => res as any[]));
    }
    
  }

  getOne(path: string, id?:number): Observable<any>{
    let geturl: string;
    if (id) {
      geturl = `${environment.apiUrl}${path}`+'/'+ id;
    } else {
      geturl = `${environment.apiUrl}${path}`
    }
    return this.http.get(geturl).pipe(
      map(res => res as any));
  }


  create(path: string, resource:any, option?:any) : Observable<any>{
    return this.http.post(`${environment.apiUrl}${path}`,resource,{headers: this.headers})
    .pipe(map((response)=>response))
  }

}
