import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from "ngx-spinner";

import { FixedIncomeComponent } from './fixed-Income/fixed-income.component';
import { CalculateInvestimentRoutingModule } from './calculate-investment.route';
import { CalculateInvestmentAppComponent } from './calculate-investment.app.component';

// import { ProdutoService } from './services/produto.service';


@NgModule({
  declarations: [
    CalculateInvestmentAppComponent,
    FixedIncomeComponent,

  ],
  imports: [
    CommonModule,
    CalculateInvestimentRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
  ],
  providers: [
    // ProdutoService,
  ]
})

export class CalculateInvestimentModule { }
