import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from '@angular/core';


import { AccountModule } from "./Features/Account/Module/account.module";
import { PurchaseModule } from "./Features/Purchase/Module/purchase.module";

import { AppComponent } from './app.component';

import { AppRoutingModule } from "./app-routing.module";

import { CustomerAccountService } from "../app/Services/customer-account.service";
import { PurchaseService } from "../app/Services/purchase.service";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,    
    HttpClientModule,
    AppRoutingModule,
    AccountModule,
    PurchaseModule
  ],
  providers: [
    CustomerAccountService,
    PurchaseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
