import { Component, OnInit } from '@angular/core';
import { HttpAuthorService } from '../Service/http.authorService';
import { AuthorListingModel } from '../Model/Author/authorListingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-authors',
  templateUrl: './list-authors.component.html',
  styleUrls: ['./list-authors.component.css'],
  providers: [HttpAuthorService]
})
export class ListAuthorsComponent implements OnInit {

  authorListingModel: AuthorListingModel[] = [];

  constructor(private httpAuthorService: HttpAuthorService, private router: Router ) { }

  ngOnInit(){
    this.httpAuthorService.getAuthorsByCount(6)
      .subscribe((response: AuthorListingModel[]) => this.authorListingModel = response);
  }
  redirect(authorId: string){
    this.router.navigate(['/author/' + authorId]);
  }
}
