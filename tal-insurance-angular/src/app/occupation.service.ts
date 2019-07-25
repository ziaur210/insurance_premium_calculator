import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Occupation } from './occupation';

@Injectable({ providedIn: 'root' })

export class OccupationService {
  
  private occupationsUrl = 'http://localhost:63513/api/occupation/list';
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient
    ) { }
 // get occupations
  getOccupations (): Observable<Occupation[]> {
    return this.http.get<Occupation[]>(this.occupationsUrl)
      .pipe(
        tap(_ => this.log('fetched occupations')),
        catchError(this.handleError<Occupation[]>('getOccupations', []))
      );
  }
 
  // handle error
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {      
      return of(result as T);
    };
  }
  /* Log message */
  private log(message: string) {
    // log  error here
  }
}