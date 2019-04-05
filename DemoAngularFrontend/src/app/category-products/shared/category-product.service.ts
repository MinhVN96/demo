import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import {Observable} from 'rxjs/observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {CategoryProduct} from './category-product.model'
@Injectable({
  providedIn: 'root'
})
export class CategoryProductService {
  selectedCategoryProduct : CategoryProduct;
  categoryProductList: CategoryProduct[];
  constructor(private http:Http) { }
  postCategoryProduc(cat:CategoryProduct){
    var body= JSON.stringify(cat);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions= new RequestOptions({method: RequestMethod.Post, headers: headersOptions});
    return this.http.post('http://localhost:64896/api/CategoryProducts',body,requestOptions).map(x => x.json());
  }
  putCategoryProduct(id,cat){
    var body = JSON.stringify(cat);
    var headersOptions= new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method: RequestMethod.Put, headers: headersOptions});
    return this.http.put('http://localhost:64896/api/CategoryProducts'+id, body,requestOptions).map(res=>res.json());
  }
  getCategoryProductList(){
    this.http.get('http://localhost:64896/api/CategoryProducts').map((data:Response)=>{return data.json() as CategoryProduct[];}).toPromise().then(x=>{this.categoryProductList=x;});
  }
  deleteCatrgoryProduct(id: number) {
    return this.http.delete('http://localhost:64896/api/CategoryProducts' + id).map(res => res.json());
  }
}
