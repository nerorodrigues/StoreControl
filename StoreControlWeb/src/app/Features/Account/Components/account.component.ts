import { Component, OnInit } from "@angular/core";

import { CustomerAccountService } from "../../../Services/customer-account.service";

@Component({
    templateUrl: "../Templates/account.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})

export class AccountComponent implements OnInit {

    count: number
    constructor(private customerAccountService: CustomerAccountService) {
        this.count = 0;
    }

    ngOnInit(): void {
        this.getNumberCustomerAccounts();
        setInterval(() => {
            this.getNumberCustomerAccounts();
        }, 60000);

    }

    getNumberCustomerAccounts() {
        this.customerAccountService.count()
            .subscribe(pX => {
                this.count = pX;
            });
    }
}