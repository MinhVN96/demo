import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Customer} from './customer.model'
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  customer : Customer;
  customerList: Customer[];
  constructor(private http:Http) { }
  postCustomer(cus:Customer){
    var body= JSON.stringify(cus);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions= new RequestOptions({method: RequestMethod.Post, headers: headersOptions});
    return this.http.post('http://localhost:64896/api/Customers',body,requestOptions).map(x => x.json());
  }
  putCustomer(id,cus){
    var body = JSON.stringify(cus);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headersOptions});
    return this.http.put('http://localhost:64896/api/Customers'+id, body,requestOptions).map(res=>res.json());
  }
  getCustomer(){
    this.http.get('http://localhost:64896/api/Customers').map((data:Response)=>{return data.json() as Customer[];}).toPromise().then(x=>{this.customerList=x;});
  }
  deleteCustomer(id: number) {
    return this.http.delete('http://localhost:64896/api/Customers' + id).map(res => res.json());
  }
}
