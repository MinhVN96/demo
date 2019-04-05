import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductComponent } from './products/product/product.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';
import { CategoryProductsComponent } from './category-products/category-products.component';
import { CategoryProductComponent } from './category-products/category-product/category-product.component';
import { CategoryProductListComponent } from './category-products/category-product-list/category-product-list.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerComponent } from './customers/customer/customer.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { SupplierComponent } from './suppliers/supplier/supplier.component';
import { SupplierListComponent } from './suppliers/supplier-list/supplier-list.component';
import { WarehousesComponent } from './warehouses/warehouses.component';
import { WarehouseComponent } from './warehouses/warehouse/warehouse.component';
import { WarehouseListComponent } from './warehouses/warehouse-list/warehouse-list.component';
import { ImportwarehouseComponent } from './importwarehouse/importwarehouse.component';
import { ImportWarehousesComponent } from './import-warehouses/import-warehouses.component';
import { ImportWarehouseComponent } from './import-warehouses/import-warehouse/import-warehouse.component';
import { ImportWarehouseListComponent } from './import-warehouses/import-warehouse-list/import-warehouse-list.component';
import { ExportWarehousesComponent } from './export-warehouses/export-warehouses.component';
import { ExportWarehouseComponent } from './export-warehouse/export-warehouse.component';
import { ExportWarehouseListComponent } from './export-warehouse-list/export-warehouse-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ProductComponent,
    ProductListComponent,
    CategoryProductsComponent,
    CategoryProductComponent,
    CategoryProductListComponent,
    CustomersComponent,
    CustomerComponent,
    CustomerListComponent,
    SuppliersComponent,
    SupplierComponent,
    SupplierListComponent,
    WarehousesComponent,
    WarehouseComponent,
    WarehouseListComponent,
    ImportwarehouseComponent,
    ImportWarehousesComponent,
    ImportWarehouseComponent,
    ImportWarehouseListComponent,
    ExportWarehousesComponent,
    ExportWarehouseComponent,
    ExportWarehouseListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
