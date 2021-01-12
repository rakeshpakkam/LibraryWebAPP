import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BooklistingService } from '../_services/booklisting.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model:any={};
books: Book[];
  constructor(private booklisting:BooklistingService) { }

  ngOnInit(): void {
  }
  search()
  {console.log('hii');
    this.booklisting.getBook(this.model.bookName).subscribe(
      books=>{
        this.books=books;
        console.log(this.books);
      }
        
    );
    // console.log(this.model);
  }
}
