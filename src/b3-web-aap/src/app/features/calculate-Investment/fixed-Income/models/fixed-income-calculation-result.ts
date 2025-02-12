/**
 * Representa o resultado do cálculo de um investimento em renda fixa.
 */
export interface FixedIncomeCalculationResult {
    /** 
     * Valor bruto total do investimento. 
     */
    grossAmount: number;

    /** 
     * Valor líquido do investimento após a tributação. 
     */
    netAmount: number;

    /** 
     * Valor do rendimento obtido com o investimento. 
     */
    returnAmount: number;

    /** 
     * Valor do imposto de renda. 
     */
    incomeTaxAmount: number;
}