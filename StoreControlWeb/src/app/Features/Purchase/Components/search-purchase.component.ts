import { Component } from "@angular/core";

import { Purchase } from "../../../Models/purchase";

import { PurchaseService } from "../../../Services/purchase.service";

import { CPFFormatPipe } from "../../Pipes/cpf-format.pipe";

@Component({
    templateUrl: "../Templates/search-purchase.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})
export class SearchPurchaseComponent {
    filter: string
    purchases: Purchase[];

    constructor(private purchaseService: PurchaseService) {

    }
    search(): void {
        if (this.filter != "" && this.filter != null) {
            this.purchaseService.search(this.filter)
                .subscribe(pX => {
                    this.purchases = pX;
                });
        } else {
            this.purchases = null;
        }
    }
}