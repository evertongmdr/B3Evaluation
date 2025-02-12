import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FixedIncomeComponent } from './fixed-Income/fixed-income.component';
import { CalculateInvestmentAppComponent } from './calculate-investment.app.component';

const calculateInvestimentRouterConfig: Routes = [
  {
    path: '', component: CalculateInvestmentAppComponent,
    children: [
      { path: 'fixed-income', component: FixedIncomeComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(calculateInvestimentRouterConfig)
  ],
  exports: [RouterModule]
})

export class CalculateInvestimentRoutingModule { }