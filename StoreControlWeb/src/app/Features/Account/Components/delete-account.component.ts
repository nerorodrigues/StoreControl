import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { CustomerAccountService } from "../../../Services/customer-account.service";

@Component({
    templateUrl: "../Templates/delete-account.component.html",
    styleUrls: [
        "../../../app.component.css"
    ]
})

export class DeleteAccountComponent implements OnInit{

    accountId:string;

    constructor(private router: Router,
        private activatedRoute: ActivatedRoute,
        private customerAccountService: CustomerAccountService){

    }
    
    ngOnInit():void{
        this.accountId = this.activatedRoute.snapshot.paramMap.get("id");
    }

    confirm(){
        this.customerAccountService.delete(this.accountId)
        .subscribe(()=>{
            this.cancel();
        });
    }

    cancel() {
        this.router.navigate(["./"], { relativeTo: this.activatedRoute.parent })
    }
}