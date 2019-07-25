import { Component, OnInit } from '@angular/core';

import { Customer } from '../customer';
import { Occupation } from '../occupation';
import { InsurancePremium } from '../customer';
import { InsurancePremiumUtility } from '../customer';
import { CustomerService } from '../customer.service';
import { OccupationService } from '../occupation.service';

'use strict'
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})


export class CustomersComponent implements OnInit {
  customers: Customer[];
  occupations: Occupation[];
  ratingFactor: number;
  monthlyPremium: number;
  newCustomerAge: number = 0;
  uiMsg: string = "";

  readonly insurancePremiumUtiltiy: InsurancePremiumUtility;

  constructor(private customerService: CustomerService, private occupationService: OccupationService, ) {
    this.insurancePremiumUtiltiy = new Customer("", "", 0, 0);
  }

  ngOnInit() {
    this.getCustomers();
    this.getOccupations();
  }
  // get customers
  getCustomers(): void {
    this.customerService.getCustomers()
      .subscribe(items => this.customers = items);
  }
  // get 
  getOccupations(): void {
    this.occupationService.getOccupations()
      .subscribe(items => this.occupations = items);
  }
  // add customer
  add(name: string, dob: string, occupationId: number, insuranceAmount: number): void {
    // validate data
    name = name.trim();
    dob = dob.trim();
    if (name.length == 0
      || dob.length == 0
      || insuranceAmount == 0
      || occupationId == 0
    ) {
      window.alert('Customer name, DOB, Occupation, Insurance amount are required input fields!');
      return;
    }

    const customerToAdd: Customer = new Customer(name, dob, occupationId, insuranceAmount);
    this.customerService.addCustomer(customerToAdd)
      .subscribe(item => {
        this.uiMsg = 'New customer added successfully.';
        // refresh customer list
        this.getCustomers();
      });
  }

  // get age
  getAge(dob: string): number {
    return this.insurancePremiumUtiltiy.getAge(dob);
  }
  // calculate age 
  calculateAge(dob: string): void {
    const age = this.insurancePremiumUtiltiy.getAge(dob);
    this.newCustomerAge = age;
    console.log(`newCustomerAge : ${age}`);
  }

  // calculate montly premium
  calculatePremium(dob: string, occupationId: number, insuranceAmount: number): void {
    // clear msg if any
    if (this.uiMsg.length > 0) { this.uiMsg = ""; }
    // validate data
    if (dob.trim().length == 0
      || occupationId == 0
      || insuranceAmount == 0
    ) {
      window.alert('DOB, Occupation, Insurance amount are required input fields!');
      return;
    }

    let selectedOccupation = this.occupations.filter(x => x.Id == occupationId)[0] as Occupation;
    let occupationRatingFactor: number = 0;
    if (selectedOccupation != null) {
       occupationRatingFactor = selectedOccupation.RatingFactor;
      // update ui for rating factor
      this.ratingFactor = occupationRatingFactor;
    }

    let InsurancePremiumParams = {} as InsurancePremium;
    InsurancePremiumParams.DOB = dob;
    InsurancePremiumParams.OccupationId = occupationId;
    InsurancePremiumParams.OccupationRatingFactor = occupationRatingFactor;
    InsurancePremiumParams.InsuranceAmount = insuranceAmount;

    const age = this.insurancePremiumUtiltiy.getAge(dob);
    this.newCustomerAge = age;
    const mPremium: number = this.insurancePremiumUtiltiy.getMonthlyPremium(InsurancePremiumParams);
    // update ui for monthly premium
    this.monthlyPremium = mPremium;
    return;
  }

} // class
