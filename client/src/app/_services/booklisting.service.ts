import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../_models/book';
import { PaginatedResult } from '../_models/pagination';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BooklistingService {
baseUrl=environment.apiUrl;
paginatedResult: PaginatedResult<Book[]>=new PaginatedResult<Book[]>();
  constructor(private http: HttpClient) { }
  getBooks(page?:number,itemsPerPage?:number)
  {
    let params=new HttpParams();
    if(page!==null && itemsPerPage!==null)
    {
      params=params.append('pageNumber',page.toString());
      params=params.append('pageSize',itemsPerPage.toString());
    }
   return this.http.get<Book[]>(this.baseUrl+'books',{observe:'response',params}).pipe(
     map(response=>{
       this.paginatedResult.result=response.body;
      
       if(response.headers.get('Pagination')!==null){
         this.paginatedResult.pagination=JSON.parse(response.headers.get('Pagination'));
         
       }
      
       return this.paginatedResult;
     })
   );
  }
  getBook(bookname:string)
  {
    return this.http.get<Book[]>(this.baseUrl+'books/'+bookname);
  }
}
