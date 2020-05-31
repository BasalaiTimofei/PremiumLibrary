import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { BookListingModel } from '../Model/Book/bookListingModel';
import { HttpBookService } from '../Service/http.bookService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css'],
  providers: [HttpBookService]
})

export class CarouselComponent implements OnInit {

  bookListingModel: BookListingModel[] = [];

  constructor(private httpBookService: HttpBookService, private router: Router) { }

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    autoplay: true,
    autoplaySpeed: 2000,
    touchDrag: false,
    pullDrag: false,
    dots: true,
    dotsSpeed: 1000,
    navSpeed: 1000,
    navText: ['Назад', 'Вперед'],
    nav: false,
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 1
      },
      740: {
        items: 1
      },
      940: {
        items: 5
      }
    },
  };

  ngOnInit(): void {
    this.httpBookService.getBooksByCount(20)
      .subscribe((response: BookListingModel[]) => this.bookListingModel = response);
  }

    redirect(bookId: string){
    this.router.navigate(['/book/' + bookId]);
  }

}
