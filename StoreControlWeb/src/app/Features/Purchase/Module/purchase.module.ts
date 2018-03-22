import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";


import { PurchaseRoutingModule } from "./purchase-routing.module";

import { PurchaseComponent } from "../Components/purchase.component";
import { AddPurchaseComponent } from "../Components/add-purchase.component";
import { ListPurchaseComponent } from "../Components/list-purchase.component";
import { DeletePurchaseComponent } from "../Components/delete-purchase.component";
import { SearchPurchaseComponent } from "../Components/search-purchase.component";

@NgModule({
    declarations: [
        PurchaseComponent,
        AddPurchaseComponent,
        ListPurchaseComponent,
        SearchPurchaseComponent,
        DeletePurchaseComponent,
    ],
    imports: [
        BrowserModule,
        FormsModule,
        PurchaseRoutingModule
    ]
})

export class PurchaseModule {

}