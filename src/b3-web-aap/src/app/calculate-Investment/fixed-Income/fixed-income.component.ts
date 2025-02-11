import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName, FormGroup, AbstractControl } from '@angular/forms';
import { FormBaseComponent } from '../../base-components/form-base.component';
import { CalculateFixedIncome } from './models/calculate-fixed-income';
import { NgxSpinnerService } from 'ngx-spinner';
import { CurrencyUtils } from '../../utils/currency-utils';

@Component({
  selector: 'app-fixed-income',
  standalone: false,
  templateUrl: './fixed-income.component.html'
})

export class FixedIncomeComponent extends FormBaseComponent {


  calculateFixedIncome!: CalculateFixedIncome;
  errors: any[] = [];
  calculateFixedIncomeForm!: FormGroup;
  showResults: boolean = false;

  financialProductTypes = [
    { label: 'CDB', value: 3, disabled: false },
    { label: 'LCI', value: 6, disabled: true },
    { label: 'LCA', value: 9, disabled: true }
  ];


  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements!: ElementRef[];

  constructor(private fb: FormBuilder, private spinner: NgxSpinnerService) {
    super();


    this.validationMessages = {

      initialValue: {
        required: 'Informe o Valor Inicial',
      },
      redemptionPeriod: {
        required: 'Informe o Período de resgate',
      },
      investmentDuration: {
        required: 'Informe o Duração total do investimento',
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
      redemptionPeriod: ['', [Validators.required]],
      investmentDuration: ['', [Validators.required]],

    });

    this.calculateFixedIncomeForm.patchValue({ bankId: '70916acf-a375-4b4d-8421-4b365301b0b0' });


    this.validarFormulario(this.calculateFixedIncomeForm);

  }



  ngAfterViewInit(): void {

    super.configurarValidacaoFormularioBase(this.formInputElements, this.calculateFixedIncomeForm);
  }


  redemptionPeriod(): AbstractControl {
    return this.calculateFixedIncomeForm.get('redemptionPeriod') as AbstractControl;
  }


  calculeIvestiment() {

    if (this.calculateFixedIncomeForm.dirty && this.calculateFixedIncomeForm.valid) {
      
      this.calculateFixedIncome = Object.assign({}, this.calculateFixedIncome, this.calculateFixedIncomeForm.value);

      console.log('antes==>',this.calculateFixedIncome)
      this.calculateFixedIncome.initialValue = CurrencyUtils.StringParaDecimal(this.calculateFixedIncome.initialValue);


      console.log('depois==>',this.calculateFixedIncome)


      

     

      // this.produtoService.novoProduto(this.produto)
      //   .subscribe({
      //     next: (sucesso: any) => { this.processarSucesso(sucesso) },
      //     error: (falha: any) => { this.processarFalha(falha) }
      //   });

      this.showResults = true;

    }

   
  }


  formatCurrency(event: any): void {

    console.log('==>', event.target);

    const formControlName = event.target.getAttribute('formControlName');

    let value = event.target.value
    var valueFormat = CurrencyUtils.formatToBRLCurrency(value)

    this.calculateFixedIncomeForm.controls[formControlName].setValue(valueFormat, { emitEvent: false });
  }

}

