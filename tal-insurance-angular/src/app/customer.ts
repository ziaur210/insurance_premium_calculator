export class Customer {
  Id: number;
  Name: string;
  DOB: string; 
  InsuranceAmount: number;
  InsuranceType: number;
  OccupationId: number;  
  OccupationName: string;
  OccupationRatingId: number;
  OccupationRatingName: string;
  OccupationRatingFactor: number;

  constructor( name: string, dob: string, occupationId: number, insuranceAmount: number) {
    this.Name = name;
    this.DOB = dob;
    this.OccupationId = occupationId;
    this.InsuranceAmount = insuranceAmount;    
  }
}
