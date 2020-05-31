import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { BookListingModel } from '../Model/Book/bookListingModel';

@Component({
  selector: 'app-top100',
  templateUrl: './top100.component.html',
  styleUrls: ['./top100.component.css'],
  providers: [HttpBookService]
})
export class Top100Component implements OnInit {

  bookListingModel: BookListingModel[] = [];

  constructor(private httpBookService: HttpBookService) { }

  ngOnInit(): void {
    this.httpBookService.getBooks()
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

}
