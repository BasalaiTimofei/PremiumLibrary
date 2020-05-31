import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { BookCommentCreateModel } from '../Model/Comment/bookCommentCreateModel';
import { AuthorCommentCreateModel } from '../Model/Comment/authorCommentCreateModel';
import { BookCommentListingModel } from '../Model/Comment/bookCommentListingModel';
import { AuthorCommentListingModel } from '../Model/Comment/authorCommentListingModel';

@Injectable()
export class HttpCommentService{
    constructor(private http: HttpClient){}

    getCommentsByBook(bookId: string){
        return this.http.get<BookCommentListingModel[]>('https://localhost:44321/api/comment/book/' + bookId);
    }

    getCommentsByAuthor(authorId: string){
        return this.http.get<AuthorCommentListingModel[]>('https://localhost:44321/api/comment/author/' + authorId);
    }

    postAddBookComment(bookCommentCreateModel: BookCommentCreateModel){
        return this.http.post('https://localhost:44321/api/comment/book', bookCommentCreateModel);
    }

    postAddAuthorComment(authorCommentCreateModel: AuthorCommentCreateModel){
        return this.http.post('https://localhost:44321/api/comment/author', authorCommentCreateModel);
    }

    deleteBookComment(commentId: string){
        return this.http.delete('https://localhost:44321/api/comment/book' + commentId);
    }

    deleteAuthorComment(commentId: string){
        return this.http.delete('https://localhost:44321/api/comment/author' + commentId);
    }

}
