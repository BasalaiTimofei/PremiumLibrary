import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-books5',
  templateUrl: './profile-books5.component.html',
  styleUrls: ['./profile-books5.component.css'],
  providers: [HttpBookService]
})
export class ProfileBooks5Component implements OnInit {

  bookListingModel: BookListingModel[] = [];

  constructor(private httpBookService: HttpBookService, private router: Router) { }

  ngOnInit(): void {
    this.httpBookService.getBooksByLike()
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

  redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }
}
