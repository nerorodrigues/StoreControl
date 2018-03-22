import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { CustomerAccountService } from "../../../Services/customer-account.service";

import { CustomerAccount } from "../../../Models/CustomerAccount";
@Component({
    templateUrl: "../Templates/add-account.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})

export class AddAccountComponent implements OnInit {

    title: string;
    accountId: string;
    customerAccount: CustomerAccount;

        constructor(private router: Router,
            private activatedRoute: ActivatedRoute,
            private customerAccountService: CustomerAccountService) {
        //Initialize objet
        this.customerAccount = new CustomerAccount();
    }

    ngOnInit(): void {
        this.accountId = this.activatedRoute.snapshot.paramMap.get("id");
        //Verify if it is a new record or a update of a existent one
        if (this.accountId === null)
            this.title = "New";
        else {
            this.title = "Update";
            this.customerAccountService.getCustomerAccount(this.accountId)
                .subscribe(pX => {
                    this.customerAccount = pX;
                })

        }

    }

    onSubmit(): void {
        this.customerAccountService.saveAccount(this.customerAccount)
            .subscribe(pX => {
                this.customerAccount = pX;
            }, error => {

            }, () => this.cancel());

    }

    cancel() {
        this.router.navigate(["./"], { relativeTo: this.activatedRoute.parent })
    }
}