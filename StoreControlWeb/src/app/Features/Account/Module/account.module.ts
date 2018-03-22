import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";

import { AccountComponent } from "../Components/account.component";
import { AddAccountComponent } from "../Components/add-account.component";
import { ListAccountComponent } from "../Components/list-account.component";
import { SearchAccountComponent } from "../Components/search-account.component";
import { DeleteAccountComponent } from "../Components/delete-account.component";

import { CPFFormatPipe  } from "../../Pipes/cpf-format.pipe";

import { AccountRoutingModule } from "./account-routing.module";

@NgModule({
    declarations:[
        CPFFormatPipe,
        AccountComponent,
        AddAccountComponent,
        ListAccountComponent,
        SearchAccountComponent,
        DeleteAccountComponent
    ],
    imports:[
        BrowserModule,
        FormsModule,
        AccountRoutingModule
    ]
})

export class AccountModule{

}