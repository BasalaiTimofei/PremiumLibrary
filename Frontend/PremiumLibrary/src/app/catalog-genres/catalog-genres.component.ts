import { Component, OnInit } from '@angular/core';
import { HttpGenreService } from '../Service/http.genreService';
import { GenreListingModel } from '../Model/Genre/genreListingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-catalog-genres',
  templateUrl: './catalog-genres.component.html',
  styleUrls: ['./catalog-genres.component.css'],
  providers: [HttpGenreService]
})
export class CatalogGenresComponent implements OnInit {

  genreListingModel: GenreListingModel[] = [];

  constructor(private httpGenreService: HttpGenreService, private router: Router) { }

  ngOnInit(): void {
    this.httpGenreService.getGenres()
      .subscribe((response: GenreListingModel[]) => this.genreListingModel = response);
  }

  redirect(genreId: string){
    this.router.navigate(['/genre/' + genreId]);
  }

}
