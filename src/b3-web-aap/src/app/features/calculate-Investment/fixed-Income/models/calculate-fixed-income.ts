export interface CalculateFixedIncome {

  bankId: string,
  financialProductType: FinancialProductType,
  initialValue: number,
  redemptionPeriod: number,
  investmentDuration: number
  
}

export enum FinancialProductType {

  CDB = 3,
  LCI = 6,
  LCA = 9

}


