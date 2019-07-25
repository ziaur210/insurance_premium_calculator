
import { Component, OnInit } from '@angular/core';

import { OccupationRating } from '../occupationRating';
import { OccupationRatingService } from '../occupationRating.service';

'use strict'
@Component({
  selector: 'app-occupation-ratings',
  templateUrl: './occupationRatings.component.html',
  styleUrls: ['./occupationRatings.component.css']
})

export class OccupationRatingsComponent implements OnInit {
  occupationRatings: OccupationRating[];

  constructor(private occupationRatingService: OccupationRatingService) {

  }

  ngOnInit() {
    this.getOccupationRatings();
  }
  // get occupation ratings
  getOccupationRatings(): void {
    this.occupationRatingService.getOccupationRatings()
      .subscribe(items => this.occupationRatings = items);
  }

} // class

