import { Component, OnInit } from '@angular/core';
import { OrderDetailService } from 'app/shared/order-detail.service';
import { Order } from 'app/shared/order.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order-detail-list',
  templateUrl: './order-detail-list.component.html',
  styles: []
})
export class OrderDetailListComponent implements OnInit {

  constructor(public service : OrderDetailService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }
  populateForm(pd: Order) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(order_id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteOrderDetail(order_id)
        .subscribe(res => {
          debugger;
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Payment Detail Register');
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }

}
