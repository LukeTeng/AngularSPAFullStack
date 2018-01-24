import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class HttpService {

    constructor(private http: Http) {

    }

    async get(url: string, params?: any) {
        let apiUrl = this.checkUrl(url);
        let response = await this.http.get(apiUrl, { params: params }).toPromise();
        return this.getResult(response);
    }


    async post(url: string, data: any) {
        let response = await this.http.post(this.checkUrl(url), data).toPromise();
        return this.getResult(response);
    }

    private getResult(response: any) {
        //console.log('http result, ', response, response.json());
        if (response && response.status === 200 && response.json().hasOwnProperty('isSuccess')
            && response.json().isSuccess === true) {
            return response.json().data;
        } else {
            //alert message here
            return null;
        }
    }

    private checkUrl(url: string): string {
        if (!url.startsWith("/") && !url.startsWith('http'))
            url = "/" + url;
        return url;
    }

}