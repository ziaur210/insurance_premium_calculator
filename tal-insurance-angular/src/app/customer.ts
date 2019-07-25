
export interface InsurancePremium {
  CustomerName?: string
  DOB: string;
  OccupationId: number;
  OccupationRatingFactor: number;
  InsuranceAmount: number
};

export interface InsurancePremiumUtility {
  getAge(dob: string): number;
  getMonthlyPremium(insurancePremiumParams: InsurancePremium): number;
};

export class Customer implements InsurancePremiumUtility {
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
    const age = this.calculateAge(dob);
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
    const mPremium: number = parseFloat(((insurancePremiumParams.InsuranceAmount * insurancePremiumParams.OccupationRatingFactor * age) / 1000 * 12).toFixed(2));
    return mPremium;
  }

} // class

