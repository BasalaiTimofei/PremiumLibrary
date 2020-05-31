import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AddAssessment } from '../Model/Dependency/addAssessment';
import { AddProcess } from '../Model/Dependency/addProcess';
import { BookCreateModel } from '../Model/Book/bookCreateModel';
import { BookListingModel } from '../Model/Book/bookListingModel';

@Injectable()
export class HttpBookService{
    headers: HttpHeaders;

    constructor(private http: HttpClient){}

    getBooks(){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book');
    }

    getBooksByCount(count: number){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book/byCount/' + count.toString());
    }

    getBookById(bookId: string){
        return this.http.get<BookListingModel>('https://localhost:44321/api/book/' + bookId);
    }

    getBooksByAuthor(authorId: string){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book/byAuthor/' + authorId);
    }

    getBooksByGenre(genreId: string){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book/byGenre/' + genreId);
    }

    getBooksByLike(){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book/byLike/');
    }

    getBookByName(bookName: string){
        return this.http.get<BookListingModel>('https://localhost:44321/api/book/byName/' + bookName);
    }

    getBooksByProcess(process: number){
        return this.http.get<BookListingModel[]>('https://localhost:44321/api/book/byProcess/' + process.toString());
    }

    postAddAssessment(addAssessmentModel: AddAssessment){
        return this.http.post<boolean>('https://localhost:44321/api/book/assessment', addAssessmentModel);
    }

    postAddOrChangeProcess(addProcessModel: AddProcess){
        return this.http.post('https://localhost:44321/api/book/process', addProcessModel);
    }

    postAddBook(bookCreateModel: BookCreateModel){
        return this.http.post<string>('https://localhost:44321/api/book/create', bookCreateModel);
    }

    deleteBook(bookId: string){
        return this.http.delete('https://localhost:44321/api/book' + bookId);
    }
}
