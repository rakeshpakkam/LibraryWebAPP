import { Component, Input, OnInit } from '@angular/core';
import { Book } from 'src/app/_models/book';

@Component({
  selector: 'app-book-cards',
  templateUrl: './book-cards.component.html',
  styleUrls: ['./book-cards.component.css']
})
export class BookCardsComponent implements OnInit {
@Input() book:Book;
  constructor() { }

  ngOnInit(): void {
  }

}
