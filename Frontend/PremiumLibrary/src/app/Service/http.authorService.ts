import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { AuthorCreateModel } from '../Model/Author/authorCreateModel';
import { AuthorListingModel } from '../Model/Author/authorListingModel';

@Injectable()
export class HttpAuthorService{
    constructor(private http: HttpClient){}

    getAuthors(){
        return this.http.get<AuthorListingModel[]>('https://localhost:44321/api/author');
    }

    getAuthorsByCount(count: number){
        return this.http.get<AuthorListingModel[]>('https://localhost:44321/api/author/byCount/' + count.toString());
    }

    getAuthorById(authorId: string){
        return this.http.get<AuthorListingModel>('https://localhost:44321/api/author/' + authorId);
    }

    getAuthorsByBook(bookId: string){
        return this.http.get<AuthorListingModel[]>('https://localhost:44321/api/author/byBook/' + bookId);
    }

    getAuthorsByLike(){
        return this.http.get<AuthorListingModel[]>('https://localhost:44321/api/author/byLike');
    }

    getAuthorByName(authorName: string){
        return this.http.get<AuthorListingModel>('https://localhost:44321/api/author/byBook/' + authorName);
    }

    postAddAuthor(authorCreateModel: AuthorCreateModel){
        return this.http.post<string>('https://localhost:44321/api/author/create', authorCreateModel);
    }

    deleteAuthor(authorId: string){
        return this.http.delete('https://localhost:44321/api/author/' + authorId);
    }
}
