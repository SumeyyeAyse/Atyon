import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Component({
  selector: 'firma',
  templateUrl: './firma.component.html'
})

export class FirmaComponent {
  http: any;
  baseURL = '';
  showSaveButton = true;
  showEditButton = false;

  public firmaList: FirmaList[] = [];

  public firmaObject: FirmaObject = {
    firmaId: null,
    firmaKod: 0,
    ad: '',
    vergiNo: ''
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
    this.http = http;
    this.load();
  }

  kaydet() {
    this.http.post(this.baseURL + 'firma/add', this.firmaObject).subscribe((result: FirmaObject) => {
      this.load();
    });
  }

  load() {
    this.http.get(this.baseURL + 'firma/list').subscribe((result: FirmaList[]) => {
      this.firmaList = result;
    });
  }

  duzenle(data: any) {
    this.firmaObject = data;
    this.showEditButton = true;
    this.showSaveButton = false;
  }

  guncelle() {
    this.http.put(this.baseURL + 'firma/put', this.firmaObject).subscribe((result: FirmaObject) => {
      this.load();
      this.showEditButton = false;
      this.showSaveButton = true;
    });
  }

  sil(firmaId: number) {
    let httpParams = new HttpParams().set('firmaId', firmaId);
    let options = { params: httpParams };
    this.http.delete(this.baseURL + 'firma/delete', options).subscribe((result: FirmaObject) => {
      this.load();
    });
  }
}

interface FirmaObject {
  firmaId: any;
  firmaKod: number;
  ad: string;
  vergiNo: string;
}

interface FirmaList {
  firmaId: number;
  firmaKod: number;
  ad: string;
  vergiNo: string;
  kayitTarihi: Date;
  guncellemeTarih: Date;
  tblTesis: any[];
}
