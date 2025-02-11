import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module'; // Verifique se o caminho está correto
import { AppComponent } from './app.component';
import { NavegationModule } from './navegation/navegation.module';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxMaskPipe, NgxMaskDirective, provideNgxMask } from 'ngx-mask';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavegationModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule,

    HttpClientModule,
    NgxMaskPipe,
    NgxMaskDirective
  ],
  providers: [
    provideNgxMask()
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }