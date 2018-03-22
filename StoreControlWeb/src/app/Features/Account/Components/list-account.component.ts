import { Component, OnInit } from "@angular/core";
import { platformBrowser } from "@angular/platform-browser";

import { CustomerAccountService } from "../../../Services/customer-account.service";

import { CustomerAccount } from "../../../Models/CustomerAccount";

@Component({
    templateUrl: "../Templates/list-account.component.html",
    styleUrls:[
        "../Styles/list-account.component.css",
        "../../../app.component.css"
    ]
})

export class ListAccountComponent implements OnInit {

    customerAccounts: CustomerAccount[];

    constructor(private accountService: CustomerAccountService) {

    }

    ngOnInit(): void {
        this.accountService.getData()
        .subscribe(pX=>{
            this.customerAccounts = pX;
        });
    }
}