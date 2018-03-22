import { Component } from "@angular/core";

import { CustomerAccount } from "../../../Models/CustomerAccount";

import { CustomerAccountService } from "../../../Services/customer-account.service";

import { CPFFormatPipe } from "../../Pipes/cpf-format.pipe";

@Component({
    templateUrl: "../Templates/search-account.component.html",
    styleUrls:[
        "../Styles/list-account.component.css",
        "../../../app.component.css"
    ]
})
export class SearchAccountComponent {
    filter: string
    customerAccounts: CustomerAccount[];

    constructor(private accountService: CustomerAccountService) {

    }
    search(): void {
        if (this.filter != "" && this.filter != null) {
            this.accountService.search(this.filter)
                .subscribe(pX => {
                    this.customerAccounts = pX;
                });
        }else{
            this.customerAccounts = null;
        }
    }
}