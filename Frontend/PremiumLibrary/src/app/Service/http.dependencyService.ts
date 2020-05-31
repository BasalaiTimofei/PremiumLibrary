import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { DependencyAuthorBook } from '../Model/Dependency/dependencyAuthorBook';
import { DependencyGenreBook } from '../Model/Dependency/dependencyGenreBook';

@Injectable()
export class HttpDependencyService{
    constructor(private http: HttpClient){}

    postAddDependencyAuthorBook(dependencyAuthorBookModel: DependencyAuthorBook){
        return this.http.post('https://localhost:44321/api/dependency/author',
            dependencyAuthorBookModel);
    }

    postAddDependencyGenreBook(dependencyGenreBookModel: DependencyGenreBook){
        return this.http.post('https://localhost:44321/api/dependency/genre',
        dependencyGenreBookModel);
    }

    deleteDependencyAuthorBook(dependencyAuthorBookModel: DependencyAuthorBook){
        return this.http.post('https://localhost:44321/api/dependency/delete/author',
            dependencyAuthorBookModel);
    }

    deleteDependencyGenreBook(dependencyGenreBookModel: DependencyGenreBook){
        return this.http.post('https://localhost:44321/api/dependency/delete/genre',
            dependencyGenreBookModel);
    }
}
