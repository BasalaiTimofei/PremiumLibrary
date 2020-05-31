import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { ActivatedRoute, Router } from '@angular/router';
import { BookListingModel } from '../Model/Book/bookListingModel';

@Component({
  selector: 'app-genre-books',
  templateUrl: './genre-books.component.html',
  styleUrls: ['./genre-books.component.css'],
  providers: [HttpBookService]
})
export class GenreBooksComponent implements OnInit {

  genreId: string;
  bookListingModel: BookListingModel[] = [];

  constructor(
    private httpBookService: HttpBookService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.genreId = parems.id);
    this.httpBookService.getBooksByGenre(this.genreId)
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

  redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }

}
