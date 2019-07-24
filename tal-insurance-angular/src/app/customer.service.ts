import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Customer } from './customer';

@Injectable({ providedIn: 'root' })

export class CustomerService {

  private customersUrl = 'http://localhost:63513/api/customer/list';
  private addCustomerUrl = 'http://localhost:63513/api/customer/Add';
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient
    ) { }
 // get customers
  getCustomers (): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.customersUrl)
      .pipe(
        tap(_ => this.log('fetched customers')),
        catchError(this.handleError<Customer[]>('getCustomers', []))
      );
  }
 // add customer
  addCustomer (customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.addCustomerUrl, customer, this.httpOptions).pipe(
      tap((newCustomer: Customer) => this.log(`added customer w/ id=${newCustomer.Id}`)),
      catchError(this.handleError<Customer>('addCustomer'))
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