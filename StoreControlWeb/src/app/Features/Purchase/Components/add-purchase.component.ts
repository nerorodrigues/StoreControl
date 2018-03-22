import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { PurchaseService } from "../../../Services/purchase.service";
import { CustomerAccountService } from "../../../Services/customer-account.service";

import { Purchase } from "../../../Models/purchase";
import { CustomerAccount } from "../../../Models/CustomerAccount";

@Component({
    templateUrl: "../Templates/add-purchase.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})

export class AddPurchaseComponent {
    title: string;
    purchaseId: string;
    purchase: Purchase;
    customerAccounts: CustomerAccount[];
    customerAccountSelected: CustomerAccount;
    isVisible: boolean = true;

    constructor(private router: Router,
        private activatedRoute: ActivatedRoute,
        private purchaseService: PurchaseService,
        private customerAccountService: CustomerAccountService) {

        this.customerAccountSelected = new CustomerAccount();
        this.purchase = new Purchase();
    }

    ngOnInit(): void {
        this.purchaseId = this.activatedRoute.snapshot.paramMap.get("id");
        //Verify if it is a new record or a update of a existent one
        if (this.purchaseId === null)
            this.title = "New";
        else {
            this.title = "Update";
            this.purchaseService.getCustomerAccount(this.purchaseId)
                .subscribe(pX => {
                    this.purchase = pX;
                    this.getCustomerAccount(pX.CustomerAccountId);
                })

        }

    }

    onSubmit(): void {

        this.purchase.CustomerAccountId = this.customerAccountSelected.ID;

        this.purchaseService.saveAccount(this.purchase)
            .subscribe(pX => {
                this.purchase = pX;
            }, error => {

            }, () => this.cancel());

    }

    cancel() {
        this.router.navigate(["./"], { relativeTo: this.activatedRoute.parent })
    }

    searchCustomerAccount() {
        this.customerAccountService.search(this.customerAccountSelected.Name)
            .subscribe(pX => {
                this.customerAccounts = pX;
                this.isVisible = true;
            })
    }

    selectCustomerAccount(customerAccount: CustomerAccount): void {
        this.customerAccountSelected = customerAccount;
        this.isVisible = false;
    }

    getCustomerAccount(customerAccountID: string): void {
        this.customerAccountService.getCustomerAccount(customerAccountID)
            .subscribe(pX => {
                this.customerAccountSelected = pX;
            })
    }
}
