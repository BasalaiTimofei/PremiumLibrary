import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { GenreCreateModel } from '../Model/Genre/genreCreateModel';
import { GenreListingModel } from '../Model/Genre/genreListingModel';

@Injectable()
export class HttpGenreService{
    constructor(private http: HttpClient){}

    getGenres(){
        return this.http.get<GenreListingModel[]>('https://localhost:44321/api/genre');
    }

    getGenresByCount(count: number){
        return this.http.get<GenreListingModel[]>('https://localhost:44321/api/genre/byCount/' + count.toString());
    }

    getGenreById(genreId: string){
        return this.http.get<GenreListingModel>('https://localhost:44321/api/genre/' + genreId);
    }

    getGenresByBook(bookId: string){
        return this.http.get<GenreListingModel[]>('https://localhost:44321/api/genre/byBook/' + bookId);
    }

    getGenresByLike(){
        return this.http.get<GenreListingModel[]>('https://localhost:44321/api/genre/byLike');
    }

    getGenresByName(genreName: string){
        return this.http.get<GenreListingModel>('https://localhost:44321/api/genre/byName/' + genreName);
    }

    postAddGenre(genreCreateModel: GenreCreateModel){
        return this.http.post('https://localhost:44321/api/genre/create', genreCreateModel);
    }

    deleteGenre(genreId: string){
        return this.http.delete('https://localhost:44321/api/genre/' + genreId);
    }
}
