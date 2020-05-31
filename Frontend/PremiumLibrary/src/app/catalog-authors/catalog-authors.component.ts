import { Component, OnInit } from '@angular/core';
import { AuthorListingModel } from '../Model/Author/authorListingModel';
import { HttpAuthorService } from '../Service/http.authorService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-catalog-authors',
  templateUrl: './catalog-authors.component.html',
  styleUrls: ['./catalog-authors.component.css'],
  providers: [HttpAuthorService]
})
export class CatalogAuthorsComponent implements OnInit {

  authorListingModel: AuthorListingModel[] = [];

  constructor(private httpAuthorService: HttpAuthorService, private router: Router) { }

  ngOnInit(){
    this.httpAuthorService.getAuthors()
      .subscribe((response: AuthorListingModel[]) => this.authorListingModel = response);
  }

  redirect(authorId: string){
    this.router.navigate(['/author/' + authorId]);
  }

}
