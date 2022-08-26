import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'atik',
  templateUrl: './atik.component.html'
})
export class AtikComponent {
  http: any;
  baseURL = '';
  showSaveButton = true;
  showEditButton = false;

  public atikList: AtikList[] = [];

  public atikObject: AtikObject = {
    atikId: null,
    atikKod: 0,
    atikAd:'',
    atikTipKod: 0
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
    this.http = http;
    this.load();
  }

  kaydet() {
    this.http.post(this.baseURL + 'atik/add', this.atikObject).subscribe((result: AtikObject) => {
      this.load();
    });
  }

  load() {
    this.http.get(this.baseURL + 'atik/list').subscribe((result: AtikList[]) => {
      this.atikList = result;
    });
  }

  duzenle(data: any) {
    this.atikObject = data;
    this.showEditButton = true;
    this.showSaveButton = false;
  }

  guncelle() {
    this.http.put(this.baseURL + 'atik/put', this.atikObject).subscribe((result: AtikObject) => {
      this.load();
      this.showEditButton = false;
      this.showSaveButton = true;
    });
  }

  sil(atikId: number) {
    let httpParams = new HttpParams().set('atikId', atikId);
    let options = { params: httpParams };
    this.http.delete(this.baseURL + 'atik/delete', options).subscribe((result: AtikObject) => {
      this.load();
    });
  }
}

interface AtikObject {
  atikId: any;
  atikKod: number;
  atikAd: string;
  atikTipKod: number;
}

interface AtikList {
  atikId: number;
  atikKod: number;
  atikAd: string;
  kayitTarih: Date;
  guncellemeTarih: Date;
  tblAtik: any[];
}

