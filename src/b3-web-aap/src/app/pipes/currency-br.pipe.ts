import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyBr'
})
export class CurrencyBrPipe implements PipeTransform {
  transform(value: string | number): string {
    if (!value) return 'R$ 0,00';

    // Converte para número caso seja string
    let numericValue = typeof value === 'string' ? parseFloat(value.replace(/\D/g, '')) / 100 : value;

    // Formata para moeda brasileira
    return numericValue.toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    });
  }
}