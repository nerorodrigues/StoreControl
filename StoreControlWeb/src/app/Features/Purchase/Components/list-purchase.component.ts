import { Component, OnInit } from "@angular/core";
import { platformBrowser } from "@angular/platform-browser";

import { PurchaseService } from "../../../Services/purchase.service";

import { Purchase } from "../../../Models/purchase";
import { CPFFormatPipe } from "../../Pipes/cpf-format.pipe";


@Component({
    templateUrl:"../Templates/list-purchase.component.html",
    styleUrls:[
        "../../../app.component.css"
    ]
})
export class ListPurchaseComponent{
    purchases: Purchase[];
    
        constructor(private purchaseService: PurchaseService) {
    
        }
    
        ngOnInit(): void {
            this.purchaseService.getData()
            .subscribe(pX=>{
                this.purchases = pX;
            });
        }
}