import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BooklistingService } from '../_services/booklisting.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
booksss: Book[];
  constructor(private booklisting:BooklistingService) { }

  ngOnInit(): void {
    this.loadListing();
  }
loadListing()
{
 
}
}
