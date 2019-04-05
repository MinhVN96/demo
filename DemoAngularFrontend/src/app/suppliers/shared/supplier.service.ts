import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Supplier} from './supplier.model'
@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  supplier : Supplier;
  supplierList: Supplier[];
  constructor(private http:Http) { }
  postSupplier(sup:Supplier){
    var body= JSON.stringify(sup);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions= new RequestOptions({method: RequestMethod.Post, headers: headersOptions});
    return this.http.post('http://localhost:64896/api/Suppliers',body,requestOptions).map(x => x.json());
  }
  putSupplier(id,sup){
    var body = JSON.stringify(sup);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headersOptions});
    return this.http.put('http://localhost:64896/api/Suppliers'+id, body,requestOptions).map(res=>res.json());
  }
  getSupplier(){
    this.http.get('http://localhost:64896/api/Suppliers').map((data:Response)=>{return data.json() as Supplier[];}).toPromise().then(x=>{this.supplierList=x;});
  }
  deleteSupplier(id: number) {
    return this.http.delete('http://localhost:64896/api/Suppliers' + id).map(res => res.json());
  }
}
