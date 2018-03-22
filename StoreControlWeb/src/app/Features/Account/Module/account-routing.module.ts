import { NgModule } from "@angular/core";
import { RouterModule, Routes, Route } from "@angular/router";

import { AccountComponent } from "../Components/account.component";
import { AddAccountComponent } from "../Components/add-account.component";
import { ListAccountComponent } from "../Components/list-account.component";
import { SearchAccountComponent } from "../Components/search-account.component";
import { DeleteAccountComponent } from "../Components/delete-account.component";
const routes: Routes = [
    {
        path: "home",
        children: [
            {
                path: "account", component: AccountComponent,
                children: [
                    { path: "", redirectTo: "list", pathMatch: "full" },
                    { path: "edit/:id", component: AddAccountComponent },
                    { path: "add", component: AddAccountComponent },
                    { path: "search", component: SearchAccountComponent },
                    { path: "list", component: ListAccountComponent },
                    { path: "delete/:id", component: DeleteAccountComponent }
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
export class AccountRoutingModule {

}