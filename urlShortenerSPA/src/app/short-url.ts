export class ShortUrl {
    id: string;
    url: string;
    longUrl: string;
    constructor(private _longUrl: string = "") {
        this.longUrl = _longUrl;
    }
}
