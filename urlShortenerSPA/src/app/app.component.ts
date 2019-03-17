import { Component, OnInit } from '@angular/core';
import { UrlShortenerService } from './url-shortener.service';
import { ShortUrl } from './short-url';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'urlShortenerSPA';
    longUrl: string;
    shortUrl: string;

    constructor(private urlShortenerService: UrlShortenerService) {}

    ngOnInit() {
        this.urlShortenerService.getShortUrls().subscribe((res) => {
            console.log(res.body);
        });
    }

    public GenerateShortUrl(): void {
        this.urlShortenerService.generateShortUrl(this.longUrl).subscribe((res) => {
            if (res.body && res.body.url) {
                this.shortUrl = res.body.url;
            }
        });
    }
}
