import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName, FormGroup } from '@angular/forms';
import { FormBaseComponent } from '../../../common/components/form-base.component';
import { CalculateFixedIncome } from './models/calculate-fixed-income';
import { NgxSpinnerService } from 'ngx-spinner';
import { CurrencyUtils } from '../../../common/utils/currency-utils';
import { StringUtils } from '../../../common/utils/string-utils';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { ApiResponse } from '../../../common/models/api-response';
import { FixedIncomeCalculationResult } from './models/fixed-income-calculation-result';

@Component({
  selector: 'app-fixed-income',
  standalone: false,
  templateUrl: './fixed-income.component.html'
})

export class FixedIncomeComponent extends FormBaseComponent {

  errors: any[] = [];
  calculateFixedIncomeForm!: FormGroup;
  showResults: boolean = false;
  urlService: string = environment.apiUrlv1;

  calculationResultDisplay: any = {};

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements!: ElementRef[];

  financialProductTypes = [
    { label: 'CDB', value: 3, disabled: false },
    { label: 'LCI', value: 6, disabled: true },
    { label: 'LCA', value: 9, disabled: true }
  ];

  constructor(private fb: FormBuilder, private spinner: NgxSpinnerService, private http: HttpClient) {
    super();


    this.validationMessages = {

      initialValue: {
        required: 'Informe o Valor Inicial',
      },
      redemptionPeriod: {
        required: 'Informe o Período de resgate',
      },
      financialProductType: {
        required: 'Informe Produto financeiro  de investimento',
      },

    };

    super.configurarMensagensValidacaoBase(this.validationMessages);

  }


  ngOnInit(): void {

    this.calculateFixedIncomeForm = this.fb.group({
      bankId: ['', [Validators.required]],
      financialProductType: ['', [Validators.required]],
      initialValue: ['', [Validators.required]],
      redemptionPeriod: ['', [Validators.required]]
    });

    this.calculateFixedIncomeForm.patchValue({ bankId: '70916acf-a375-4b4d-8421-4b365301b0b0' });

    this.validarFormulario(this.calculateFixedIncomeForm);

  }

  ngAfterViewInit(): void {

    super.configurarValidacaoFormularioBase(this.formInputElements, this.calculateFixedIncomeForm);

  }

  formatCalculationResultForDisplay(calculationResult: FixedIncomeCalculationResult | null) {

    return {
      grossAmount: CurrencyUtils.formatToBRL(calculationResult?.grossAmount),
      netAmount: CurrencyUtils.formatToBRL(calculationResult?.netAmount),
      returnAmount: CurrencyUtils.formatToBRL(calculationResult?.returnAmount),
      incomeTaxAmount: CurrencyUtils.formatToBRL(calculationResult?.incomeTaxAmount)
    }

  }

  mapFormToFixedIncomeCalculation(calculateFixedIncomeForm: FormGroup): CalculateFixedIncome {

    var calculateFixedIncome = {} as CalculateFixedIncome;

    calculateFixedIncome = Object.assign({}, calculateFixedIncome, calculateFixedIncomeForm.value);

    calculateFixedIncome.financialProductType = StringUtils.stringToInt(this.calculateFixedIncomeForm.value.financialProductType);
    calculateFixedIncome.initialValue = CurrencyUtils.StringParaDecimal(this.calculateFixedIncomeForm.value.initialValue);

    return calculateFixedIncome;
  }

  calculeIvestiment() {

    if (this.calculateFixedIncomeForm.dirty && this.calculateFixedIncomeForm.valid) {

      this.showResults = false;
      this.spinner.show();

      var calculateFixedIncome = this.mapFormToFixedIncomeCalculation(this.calculateFixedIncomeForm);

      this.http
        .post<ApiResponse<FixedIncomeCalculationResult>>(this.urlService + 'investments/calculate-fixed-income',
          calculateFixedIncome).subscribe({
            next: dataResponse => {

              this.errors = []
              this.showResults = true;
              this.spinner.hide();

              this.calculationResultDisplay = this.formatCalculationResultForDisplay(dataResponse.data)
            },
            error: errorHttp => {

              this.errors = []

              if (errorHttp?.error?.success === false) {
                this.errors = errorHttp.error.errors;
              } else {
                this.errors = ['Ocorreu um erro inesperado no sistema, detalhes foram registrados.'];
              }

              this.showResults = false;
              this.spinner.hide();
            }

          });
    }
  }

  formatCurrency(event: any): void {

    const formControlName = event.target.getAttribute('formControlName');

    let value = event.target.value
    var valueFormat = CurrencyUtils.formatToBRLCurrency(value)

    this.calculateFixedIncomeForm.controls[formControlName].setValue(valueFormat, { emitEvent: false });
  }

}

