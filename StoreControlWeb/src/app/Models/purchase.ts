import { ModelBase } from "./ModelBase";
import { CustomerAccount } from "./CustomerAccount";
export class Purchase {
    Description: string;
    CustomerAccountId: string;
    Amount: number;
    CustomerAccount: CustomerAccount;
}