import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Observable } from "rxjs/Observable";
import { catchError } from "rxjs/operators";
import { CustomerAccount } from "../Models/CustomerAccount";

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const apiUrl = "http://localhost:64527/api/CustomerAccount";

@Injectable()
export class CustomerAccountService {
    constructor(private httpClient: HttpClient) {

    }


    delete(customerAccountId: string): Observable<void> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pCustomerAccountId": customerAccountId
            }

        };
        return this.httpClient.delete<void>(apiUrl, options);
    }


    getData(): Observable<CustomerAccount[]> {
        return this.httpClient.get<CustomerAccount[]>(apiUrl + "/list", httpOptions);
    }

    search(filter: string): Observable<CustomerAccount[]> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pFilter": filter
            }

        };
        return this.httpClient.get<CustomerAccount[]>(apiUrl + "/search", options);
    }

    getCustomerAccount(customerAccountId: string): Observable<CustomerAccount> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pCustomerAccountId": customerAccountId
            }

        };
        return this.httpClient.get<CustomerAccount>(apiUrl, options);
    }

    saveAccount(data: CustomerAccount): Observable<CustomerAccount> {
        return this.httpClient.post<CustomerAccount>(apiUrl, data, httpOptions);
    }

    count(): Observable<number> {
        return this.httpClient.get<number>(apiUrl + "/count", httpOptions);
    }
}