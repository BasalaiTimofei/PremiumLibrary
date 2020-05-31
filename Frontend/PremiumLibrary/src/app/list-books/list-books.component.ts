import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.css'],
  providers: [HttpBookService]
})
export class ListBooksComponent implements OnInit {

  bookListingModel: BookListingModel[] = [];

  constructor(private httpBookService: HttpBookService, private router: Router) { }

  ngOnInit(): void {
    this.httpBookService.getBooksByCount(40)
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

  redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }

}
