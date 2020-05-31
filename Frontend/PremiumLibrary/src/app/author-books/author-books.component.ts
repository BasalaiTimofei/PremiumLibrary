import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-author-books',
  templateUrl: './author-books.component.html',
  styleUrls: ['./author-books.component.css'],
  providers: [HttpBookService]
})
export class AuthorBooksComponent implements OnInit {

  authorId: string;
  bookListingModel: BookListingModel[] = [];

  constructor(
    private httpBookService: HttpBookService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.authorId = parems.id);
    this.httpBookService.getBooksByAuthor(this.authorId)
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

  redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }
}
