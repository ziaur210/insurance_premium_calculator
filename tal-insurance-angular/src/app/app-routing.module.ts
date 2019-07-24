import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomersComponent }      from './customers/customers.component';

const routes: Routes = [
   { path: '', redirectTo: '/customers', pathMatch: 'full' },
   { path: 'customers', component: CustomersComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

