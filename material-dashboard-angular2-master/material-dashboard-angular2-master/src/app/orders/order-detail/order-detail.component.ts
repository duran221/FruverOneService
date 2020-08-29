import { Component, OnInit } from '@angular/core';
import { OrderDetailService } from 'app/shared/order-detail.service';


@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styles: []
})
export class OrderDetailComponent implements OnInit {

  constructor(public service: OrderDetailService) { }

  ngOnInit(): void {
  }

}
