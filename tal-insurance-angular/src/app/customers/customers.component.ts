import { Component, OnInit } from '@angular/core';

import { Customer } from '../customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  ratingFactor: number;
  monthlyPremium: number;

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getCustomers()
      .subscribe(items => this.customers = items);
  }
 // add customer
  add(name: string, dob: string, occupationId: number, insuranceAmount: number): void {
    // validate data
    name = name.trim();
    dob = dob.trim();
    if (!name
      || !dob
    ) { return; }

    const customerToAdd: Customer = new Customer(name, dob, occupationId, insuranceAmount);
    this.customerService.addCustomer(customerToAdd)
      .subscribe(item => {       
        // customerToAdd.OccupationName = '';
        // this.customers.push(customerToAdd);
        // refresh customer list
        this.getCustomers();
      });
  }
  // get age
  getAge(dob: string): number 
  {
    var now = new Date();
    var birthDate = new Date(dob);
    var timeDiff = Math.abs(now.getTime() - birthDate.getTime());
    var dayDifference = parseFloat((timeDiff / (1000 * 3600 * 24 * 365)).toFixed(2));
    return dayDifference;
  }
  // calculate montly premium
  calculatePremium(dob: string, occupationId: number, insuranceAmount: number): number 
  {   
    // validate data
    if (dob.trim() == ""
      || occupationId == 0
      || insuranceAmount == 0
    )
      return;

    const age: number = this.getAge(dob);
    const OccupationRatingFactor: number = this.getOccupationFactor(occupationId);
    this.ratingFactor = OccupationRatingFactor;
    console.log(`${insuranceAmount} ${OccupationRatingFactor} ${age} `);
    const mPremium: number = parseFloat(((insuranceAmount * OccupationRatingFactor * age) / 1000 * 12).toFixed(2));
    console.log(`montlyPremium = ${mPremium}`);
    this.monthlyPremium = mPremium;
    return mPremium;
  }

  //-----------------------------------------
  getOccupationFactor(occupationId: number): number {
    return this.getOccupationRatingFactor(this.getOccupationRatingId(occupationId));
  }
  //---------------------------------------
  getOccupationRatingId(occupationId: number): number {
    switch (occupationId % 7) {
      case 1:
        return 3;
      case 2:
        return 1;
      case 3:
        return 2;
      case 4:
        return 4;
      case 5:
        return 4;
      case 6:
        return 3;
      default:
        return 0;
    }
  } // function

  getOccupationRatingFactor(ratingId: number): number {
    // let ratingFactor: number = 0;
    switch (ratingId % 5) {
      case 1:
        return 1.00;
      case 2:
        return 1.25;
      case 3:
        return 1.50;
      case 4:
        return 1.75;
      default:
        return 0;
    }
  } // function

} // class
