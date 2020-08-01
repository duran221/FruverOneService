import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {  Product} from "./product.model";

@Injectable({
  providedIn: 'root'
})
export class ListProductService {

  readonly rootURL = 'https://localhost:44304/api/';
  public list : [];
  constructor(private http: HttpClient) { }

  getlistFruits(){
    this.http.get(this.rootURL + 'GetListProduct?typeProduct=FRUTA')
    .toPromise()
    .then(res => this.list);
  }

}
