import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Warehouse} from './warehouse.model'
@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  warehouse : Warehouse;
  warehouseList: Warehouse[];
  constructor(private http:Http) { }
  postWarehouse(war:Warehouse){
    var body= JSON.stringify(war);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions= new RequestOptions({method: RequestMethod.Post, headers: headersOptions});
    return this.http.post('http://localhost:64896/api/Warehouses',body,requestOptions).map(x => x.json());
  }
  putWarehouse(id,war){
    var body = JSON.stringify(war);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headersOptions});
    return this.http.put('http://localhost:64896/api/Warehouses'+id, body,requestOptions).map(res=>res.json());
  }
  getWarehouse(){
    this.http.get('http://localhost:64896/api/Warehouses').map((data:Response)=>{return data.json() as Warehouse[];}).toPromise().then(x=>{this.warehouseList=x;});
  }
  deleteWarehouse(id: number) {
    return this.http.delete('http://localhost:64896/api/Warehouses' + id).map(res => res.json());
  }
}
