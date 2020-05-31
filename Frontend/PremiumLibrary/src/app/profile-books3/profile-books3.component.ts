import { Component, OnInit } from '@angular/core';
import { HttpBookService } from '../Service/http.bookService';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-books3',
  templateUrl: './profile-books3.component.html',
  styleUrls: ['./profile-books3.component.css'],
  providers: [HttpBookService]
})
export class ProfileBooks3Component implements OnInit {

  bookListingModel: BookListingModel[] = [];

  constructor(private httpBookService: HttpBookService, private router: Router) { }

  ngOnInit(): void {
    this.httpBookService.getBooksByProcess(3)
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

  redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }
}
