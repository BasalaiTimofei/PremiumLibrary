import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { HttpAuthorService } from '../Service/http.authorService';
import { HttpGenreService } from '../Service/http.genreService';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { AuthorListingModel } from '../Model/Author/authorListingModel';
import { GenreListingModel } from '../Model/Genre/genreListingModel';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  providers: [
    HttpBookService,
    HttpAuthorService,
    HttpGenreService
  ]
})
export class BookComponent implements OnInit {

  bookId: string;
  bookListingModel: BookListingModel;
  authorsListingModel: AuthorListingModel[] = [];
  genresListingModel: GenreListingModel[] = [];

  constructor(
    private httpBookService: HttpBookService,
    private httpAuthorService: HttpAuthorService,
    private httpGenreService: HttpGenreService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(){
    this.route.params.subscribe(parems => this.bookId = parems.id);
    this.httpBookService.getBookById(this.bookId)
      .subscribe((response: BookListingModel) => this.bookListingModel = response);
    this.httpAuthorService.getAuthorsByBook(this.bookId)
      .subscribe((response: AuthorListingModel[]) => this.authorsListingModel = response);
    this.httpGenreService.getGenresByBook(this.bookId)
      .subscribe((response: GenreListingModel[]) => this.genresListingModel = response);
  }

  redirectAuthor(authorId: string){
    this.router.navigate(['/author/' + authorId]);
  }

  redirectGenre(genreId: string){
    this.router.navigate(['/genre/' + genreId]);
  }

}
