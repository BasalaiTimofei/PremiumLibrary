import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { Top100Component } from './top100/top100.component';
import { AdminpanelComponent } from './adminpanel/adminpanel.component';
import { AuthorComponent } from './author/author.component';
import { BookComponent } from './book/book.component';
import { GenreComponent } from './genre/genre.component';
import { CatalogAuthorsComponent } from './catalog-authors/catalog-authors.component';
import { CatalogBooksComponent } from './catalog-books/catalog-books.component';
import { CatalogGenresComponent } from './catalog-genres/catalog-genres.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
    { path: '', children: [
        { path: '', redirectTo: '/main', pathMatch: 'full' },
        { path: 'main', component: MainComponent },
        { path: 'top100', component: Top100Component },
        { path: 'adminpanel', component: AdminpanelComponent },
        { path: 'author/:id', component: AuthorComponent },
        { path: 'book/:id', component: BookComponent },
        { path: 'genre/:id', component: GenreComponent },
        { path: 'catalog-authors', component: CatalogAuthorsComponent },
        { path: 'catalog-book', component: CatalogBooksComponent },
        { path: 'catalog-genre', component: CatalogGenresComponent },
        { path: 'profile', component: ProfileComponent }
    ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
