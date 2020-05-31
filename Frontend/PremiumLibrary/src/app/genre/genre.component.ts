import { Component, OnInit } from '@angular/core';
import { HttpGenreService } from '../Service/http.genreService';
import { GenreListingModel } from '../Model/Genre/genreListingModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css'],
  providers: [HttpGenreService]
})
export class GenreComponent implements OnInit {

  genreId: string;
  genreListingModel: GenreListingModel;

  constructor(private httpGenreService: HttpGenreService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(parems => this.genreId = parems.id);
    this.httpGenreService.getGenreById(this.genreId)
      .subscribe((response: GenreListingModel) => this.genreListingModel = response);
  }
}
