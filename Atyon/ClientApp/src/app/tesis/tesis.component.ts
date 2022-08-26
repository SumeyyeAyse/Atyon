import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Component({
  selector: 'tesis',
  templateUrl: './tesis.component.html'
})

export class TesisComponent {
  http: any;
  baseURL = '';
  showSaveButton = true;
  showEditButton = false;

  public tesisList: TesisList[] = [];

  public tesisObject: TesisObject = {
    tesisId: null,
    tesisKod: 0,
    firmaKod: 0,
    ilceKod: 0
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
    this.http = http;
    this.load();
  }

  kaydet() {
    debugger
    this.http.post(this.baseURL + 'tesis/add', this.tesisObject).subscribe((result: TesisObject) => {
      this.load();
    });
  }

  load() {
    this.http.get(this.baseURL + 'tesis/list').subscribe((result: TesisList[]) => {
      this.tesisList = result;
    });
  }

  duzenle(data: any) {
    this.tesisObject = data;
    this.showEditButton = true;
    this.showSaveButton = false;
  }

  guncelle() {
    this.http.put(this.baseURL + 'tesis/put', this.tesisObject).subscribe((result: TesisObject) => {
      this.load();
      this.showEditButton = false;
      this.showSaveButton = true;
    });
  }

  sil(tesisId: number) {
    let httpParams = new HttpParams().set('tesisId', tesisId);
    let options = { params: httpParams };
    this.http.delete(this.baseURL + 'tesis/delete', options).subscribe((result: TesisObject) => {
      this.load();
    });
  }
}

interface TesisObject {
  tesisId: any;
  tesisKod: number;
  firmaKod: number;
  ilceKod: number;
}

interface TesisList {
  tesisId: number;
  tesisKod: number;
  firmaKod: number;
  ilceKod: number;
  kayitTarih: Date;
  guncellemeTarih: Date;
  tblAtikStokHarekets: any[];
  tblTesisNitelikTips: any[];
  tblUretims: any[];
}
