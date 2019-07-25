import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomersComponent }      from './customers/customers.component';
import { OccupationsComponent }      from './occupations/occupations.component';
import { OccupationRatingsComponent }      from './occupationRatings/occupationRatings.component';

const routes: Routes = [
   { path: '', redirectTo: '/customers', pathMatch: 'full' },
   { path: 'customers', component: CustomersComponent },
   { path: 'occupations', component: OccupationsComponent },   
   { path: 'ratings', component: OccupationRatingsComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

