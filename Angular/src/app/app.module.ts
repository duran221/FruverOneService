import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ListProductComponent } from './list-product/list-product.component';
import { HttpClientModule } from '@angular/common/http';
import { ListProductService } from './servicios/list-product.service';

@NgModule({
  declarations: [
    AppComponent,
    ListProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [ListProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
