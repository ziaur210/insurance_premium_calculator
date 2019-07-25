

import { Component, OnInit } from '@angular/core';

import { Occupation } from '../occupation';
import { OccupationService } from '../occupation.service';

'use strict'
@Component({
  selector: 'app-occupations',
  templateUrl: './occupations.component.html',
  styleUrls: ['./occupations.component.css']
})

export class OccupationsComponent implements OnInit {
  occupations: Occupation[];

  constructor(private occupationService: OccupationService) {

  }


  ngOnInit() {
    this.getOccupations();
  }
  // get customers
  getOccupations(): void {
    this.occupationService.getOccupations()
      .subscribe(items => this.occupations = items);
  }

} // class

