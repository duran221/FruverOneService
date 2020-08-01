import { Component, OnInit } from '@angular/core';
import { ListProductService } from '../servicios/list-product.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html'
})
export class ListProductComponent implements OnInit {


  constructor(private listProductService:  ListProductService) { }

  ngOnInit(): void {
    this.listProductService.getlistFruits();
    console.log(this.listProductService.list);
  }

}
