import { Injectable } from '@angular/core'
import { Http, Headers } from '@angular/http'
import 'rxjs/add/operator/map'

@Injectable()

export class BowlingService{
    headers: Headers
    constructor(private http: Http) {
        console.log('BowlingService initialezed ...');
        this.headers = new Headers();
        this.headers.append('content-type', 'application/json');
    }

    calculateScore(postData: string) {
        return this.http.post('http://localhost:54826/api/Score/CalculateScore', postData, {
            headers: this.headers
        })
            .map(res => res.json());
    }
}