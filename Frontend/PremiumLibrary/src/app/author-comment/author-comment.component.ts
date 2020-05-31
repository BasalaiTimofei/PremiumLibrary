import { Component, OnInit } from '@angular/core';
import { HttpCommentService } from '../Service/http.commentService';
import { AuthorCommentListingModel } from '../Model/Comment/authorCommentListingModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-author-comment',
  templateUrl: './author-comment.component.html',
  styleUrls: ['./author-comment.component.css'],
  providers: [HttpCommentService]
})
export class AuthorCommentComponent implements OnInit {

  authorId: string;
  authorCommentListingModel: AuthorCommentListingModel[] = [];

  constructor(private httpCommentService: HttpCommentService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.authorId = parems.id);
    this.httpCommentService.getCommentsByAuthor(this.authorId)
      .subscribe((response: AuthorCommentListingModel[]) => this.authorCommentListingModel = response);
  }

}
