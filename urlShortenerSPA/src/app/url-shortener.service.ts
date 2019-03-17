import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShortUrl } from './short-url';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UrlShortenerService {
  
    apiUrl: string = 'http://localhost:5001/api/shorturls/';

    constructor(private httpClient: HttpClient) { }

    public getShortUrlByUrl(url: string) {

    }

    public getShortUrls() {
        return this.httpClient.get < ShortUrl[] >(this.apiUrl, {observe: 'response'});
    }
}
