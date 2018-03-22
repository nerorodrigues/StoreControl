import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { PurchaseService } from "../../../Services/purchase.service";

@Component({
    templateUrl:"../Templates/delete-purchase.component.html"
})

export class DeletePurchaseComponent{
    purchaseId:string;
    
        constructor(private router: Router,
            private activatedRoute: ActivatedRoute,
            private purchaseService: PurchaseService){
    
        }
        
        ngOnInit():void{
            this.purchaseId = this.activatedRoute.snapshot.paramMap.get("id");
        }
    
        confirm(){
            this.purchaseService.delete(this.purchaseId)
            .subscribe(()=>{
                this.cancel();
            });
        }
    
        cancel() {
            this.router.navigate(["./"], { relativeTo: this.activatedRoute.parent })
        }
}