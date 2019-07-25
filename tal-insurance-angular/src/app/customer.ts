
export interface InsurancePremium {
  CustomerName?: string
  DOB: string;
  OccupationId: number;
  InsuranceAmount: number
};

export interface InsurancePremiumUtility {
  getAge(dob: string): number;
  getCustomerOccupationRatingFactor(occupationId: number): number;
  getMonthlyPremium(insurancePremiumParams: InsurancePremium): number;
};

export class Customer implements InsurancePremiumUtility{
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

  constructor(name: string, dob: string, occupationId: number, insuranceAmount: number) {
    this.Name = name;
    this.DOB = dob;
    this.OccupationId = occupationId;
    this.InsuranceAmount = insuranceAmount;
  }
  getAge(dob: string): number {
    // console.log(`new customer dob : ${dob}`);
    const age = this.calculateAge(dob);
    //this.newCustomerAge = age;
    // console.log(`newCustomerAge : ${age}`);
    return age;
  }
  // get age
  private calculateAge(dob: string): number {
    var now = new Date();
    var birthDate = new Date(dob);
    var timeDiff = Math.abs(now.getTime() - birthDate.getTime());
    var dayDifference = parseFloat((timeDiff / (1000 * 3600 * 24 * 365)).toFixed(2));
    return dayDifference;
  }

  getMonthlyPremium(insurancePremiumParams: InsurancePremium): number {

    const age: number = this.getAge(insurancePremiumParams.DOB);
    // console.log(`new customer age = ${age}`);
    // update ui for age
    // this.newCustomerAge = age;
    const occupationRatingFactor: number = this.getCustomerOccupationRatingFactor(insurancePremiumParams.OccupationId);
    // update ui for rating factor
    // this.ratingFactor = OccupationRatingFactor;
    // console.log(`${insuranceparams.InsuranceAmount} ${OccupationRatingFactor} ${age} `);

    const mPremium: number = parseFloat(((insurancePremiumParams.InsuranceAmount * occupationRatingFactor * age) / 1000 * 12).toFixed(2));
    return mPremium;
  }

  //-----------------------------------------
  getCustomerOccupationRatingFactor(occupationId: number): number {
    return this.getOccupationRatingFactor(this.getOccupationRatingId(occupationId));
  }

  private getOccupationRatingId(occupationId: number): number {
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

  private getOccupationRatingFactor(ratingId: number): number {
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

