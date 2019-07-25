import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { OccupationRating } from './occupationRating';

@Injectable({ providedIn: 'root' })

export class OccupationRatingService {
  
  private occupationRatingsUrl = 'http://localhost:63513/api/occupation-rating/list';
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient
    ) { }
 // get occupation ratings
 getOccupationRatings (): Observable<OccupationRating[]> {
    return this.http.get<OccupationRating[]>(this.occupationRatingsUrl)
      .pipe(
        tap(_ => this.log('fetched occupationRatings')),
        catchError(this.handleError<OccupationRating[]>('getOccupationRatings', []))
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