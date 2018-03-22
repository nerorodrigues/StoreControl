import { NgModule } from "@angular/core";
import { RouterModule, Routes, Route } from "@angular/router";

import { PurchaseComponent } from "../Components/purchase.component";
import { AddPurchaseComponent } from "../Components/add-purchase.component";
import { ListPurchaseComponent } from "../Components/list-purchase.component";
import { DeletePurchaseComponent } from "../Components/delete-purchase.component";
import { SearchPurchaseComponent } from "../Components/search-purchase.component";
const routes: Routes = [
    {
        path: "home",
        children: [
            {
                path: "purchase", component: PurchaseComponent,
                children: [
                    { path: "", redirectTo: "list", pathMatch: "full" },
                    { path: "edit/:id", component: AddPurchaseComponent },
                    { path: "add", component: AddPurchaseComponent },
                    { path: "list", component: ListPurchaseComponent },
                    { path: "search", component: SearchPurchaseComponent },
                    { path: "delete/:id", component: DeletePurchaseComponent }
                ]
            }
        ]
    }
]

@NgModule({
    exports: [
        RouterModule
    ],
    imports: [
        RouterModule.forChild(routes)
    ]
})
export class PurchaseRoutingModule {

}