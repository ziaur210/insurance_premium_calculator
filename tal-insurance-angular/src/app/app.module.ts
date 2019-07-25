import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { AppRoutingModule }     from './app-routing.module';

import { AppComponent }         from './app.component';

import { CustomersComponent }   from './customers/customers.component';
import { OccupationsComponent }      from './occupations/occupations.component';
import { OccupationRatingsComponent }      from './occupationRatings/occupationRatings.component';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  declarations: [
    AppComponent,
    CustomersComponent,
    OccupationsComponent,
    OccupationRatingsComponent,
  ],
  bootstrap: [ AppComponent ]
})

export class AppModule { }
