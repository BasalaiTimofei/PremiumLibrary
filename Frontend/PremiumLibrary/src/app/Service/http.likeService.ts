import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class HttpLikeService{
    constructor(private http: HttpClient){}

    getLikeBook(bookId: string){
        return this.http.get('https://localhost:44321/api/like/book/' + bookId);
    }

    getLikeAuthor(authorId: string){
        return this.http.get('https://localhost:44321/api/like/author/' + authorId);
    }

    getLikeGenre(genreId: string){
        return this.http.get('https://localhost:44321/api/like/genre/' + genreId);
    }

    getAddBookCommentLike(commentId: string){
        return this.http.get('https://localhost:44321/api/like/book/comment/' + commentId);
    }

    getAddAuthorCommentLike(commentId: string){
        return this.http.get('https://localhost:44321/api/like/author/comment/' + commentId);
    }

    deleteLikeBook(bookId: string){
        return this.http.delete('https://localhost:44321/api/like/book/' + bookId);
    }

    deleteLikeAuthor(authorId: string){
        return this.http.delete('https://localhost:44321/api/like/author/' + authorId);
    }

    deleteLikeGenre(genreId: string){
        return this.http.delete('https://localhost:44321/api/like/genre/' + genreId);
    }

    deleteAddBookCommentLike(commentId: string){
        return this.http.delete('https://localhost:44321/api/like/book/comment/' + commentId);
    }

    deleteAddAuthorCommentLike(commentId: string){
        return this.http.delete('https://localhost:44321/api/like/author/comment/' + commentId);
    }

}
