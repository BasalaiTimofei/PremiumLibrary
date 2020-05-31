import { Component, OnInit } from '@angular/core';
import { HttpAuthorService } from '../Service/http.authorService';
import { AuthorListingModel } from '../Model/Author/authorListingModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
  providers: [HttpAuthorService]
})
export class AuthorComponent implements OnInit {

  authorListingModel: AuthorListingModel;
  authorId: string;

  constructor(private httpAuthorService: HttpAuthorService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.authorId = parems.id);
    this.httpAuthorService.getAuthorById(this.authorId)
      .subscribe((response: AuthorListingModel) => this.authorListingModel = response);
  }
}
