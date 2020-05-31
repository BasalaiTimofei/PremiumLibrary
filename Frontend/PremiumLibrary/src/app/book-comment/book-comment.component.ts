import { Component, OnInit } from '@angular/core';
import { BookCommentListingModel } from '../Model/Comment/bookCommentListingModel';
import { HttpCommentService } from '../Service/http.commentService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-comment',
  templateUrl: './book-comment.component.html',
  styleUrls: ['./book-comment.component.css'],
  providers: [HttpCommentService]
})
export class BookCommentComponent implements OnInit {

  bookId: string;
  bookCommentListingModel: BookCommentListingModel[] = [];

  constructor(private httpCommentService: HttpCommentService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.bookId = parems.id);
    this.httpCommentService.getCommentsByBook(this.bookId)
      .subscribe((response: BookCommentListingModel[]) => this.bookCommentListingModel = response);
  }
}
