import { Component } from "@angular/core";

import { PurchaseService } from "../../../Services/purchase.service";

@Component({
    templateUrl:"../Templates/purchase.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})

export class PurchaseComponent{
    count: number
    constructor(private purchaseService: PurchaseService) {
        this.count = 0;
    }

    ngOnInit(): void {
        this.getNumberCustomerAccounts();
        setInterval(() => {
            this.getNumberCustomerAccounts();
        }, 60000);

    }

    getNumberCustomerAccounts() {
        this.purchaseService.count()
            .subscribe(pX => {
                this.count = pX;
            });
    }
}