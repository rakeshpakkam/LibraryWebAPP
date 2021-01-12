import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/_models/book';
import { Pagination } from 'src/app/_models/pagination';
import { BooklistingService } from 'src/app/_services/booklisting.service';

@Component({
  selector: 'app-book-listing',
  templateUrl: './book-listing.component.html',
  styleUrls: ['./book-listing.component.css']
})
export class BookListingComponent implements OnInit {
  model:any={};
  booksss: Book[];
  pagination:Pagination;
  pageNumber=1;
  pageSize=5;
  constructor(private booklisting:BooklistingService) { }

  ngOnInit(): void {
    this.loadListing();
  }
  loadListing()
  {
    this.booklisting.getBooks(this.pageNumber,this.pageSize).subscribe(response=>{
      this.booksss=response.result;
      console.log(response);
      this.pagination = response.pagination;
    }
    )
  
  }
  search()
  {
  console.log(this.model.bookName);
    this.booklisting.getBook(this.model.bookName).subscribe(      books=>{
        this.booksss=books;
        console.log(this.booksss);
      }
        
    );
   
  }
  pageChanged(event: any)
    {
      this.pageNumber=event.page;
      this.loadListing();
    }
}
