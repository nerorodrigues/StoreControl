import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Observable } from "rxjs/Observable";
import { catchError } from "rxjs/operators";
import { Purchase } from "../Models/purchase";

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const apiUrl = "http://localhost:64527/api/Purchase";

@Injectable()
export class PurchaseService {
    constructor(private httpClient: HttpClient) {

    }


    delete(customerAccountId: string): Observable<void> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pPurchaseId": customerAccountId
            }

        };
        return this.httpClient.delete<void>(apiUrl, options);
    }


    getData(): Observable<Purchase[]> {
        return this.httpClient.get<Purchase[]>(apiUrl + "/list", httpOptions);
    }

    search(filter: string): Observable<Purchase[]> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pFilter": filter
            }

        };
        return this.httpClient.get<Purchase[]>(apiUrl + "/search", options);
    }

    getCustomerAccount(customerAccountId: string): Observable<Purchase> {
        var options = {
            headers: httpOptions.headers,
            params: {
                "pPurchaseId": customerAccountId
            }

        };
        return this.httpClient.get<Purchase>(apiUrl, options);
    }

    saveAccount(data: Purchase): Observable<Purchase> {
        return this.httpClient.post<Purchase>(apiUrl, data, httpOptions);
    }

    count(): Observable<number> {
        return this.httpClient.get<number>(apiUrl + "/count", httpOptions);
    }
}