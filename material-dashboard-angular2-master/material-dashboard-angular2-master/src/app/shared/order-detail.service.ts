import { Injectable } from '@angular/core';
import { OrderDetailComponent } from 'app/orders/order-detail/order-detail.component';
import { Order } from './order.model';
import { HttpClient } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class OrderDetailService {
  formData: Order;
  readonly rootURL = 'http://localhost:58460/api';

  list : Order[];

  constructor(private http: HttpClient) { }

  deleteOrderDetail(id) {
    return this.http.delete(this.rootURL + '/Order/'+ id);
  }

    refreshList(){
      this.http.get(this.rootURL + '/Order')  
      .toPromise()
      .then(res => this.list = res as Order[]);
    }

  
}
