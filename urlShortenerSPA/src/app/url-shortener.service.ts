import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShortUrl } from './short-url';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UrlShortenerService {

    apiUrl = 'http://localhost:5000/api/shorturls/';

    constructor(private httpClient: HttpClient) { }

    public getShortUrlByUrl(url: string) {
        return this.httpClient.get < ShortUrl[] >(`${this.apiUrl}${url}`, {observe: 'response'});
    }

    public getShortUrls() {
        return this.httpClient.get < ShortUrl[] >(this.apiUrl, {observe: 'response'});
    }

    public generateShortUrl(longUrl: string) {
        const createModel = new ShortUrl(longUrl);
        return this.httpClient.post(this.apiUrl, createModel, {observe: 'response'});
    }
}
