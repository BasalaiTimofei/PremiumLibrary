import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HeaderComponent } from './header/header.component';
import { CarouselComponent } from './carousel/carousel.component';
import { MainComponent } from './main/main.component';
import { ListBooksComponent } from './list-books/list-books.component';
import { ListAuthorsComponent } from './list-authors/list-authors.component';
import { ListGenresComponent } from './list-genres/list-genres.component';
import { Top100Component } from './top100/top100.component';
import { CatalogAuthorsComponent } from './catalog-authors/catalog-authors.component';
import { CatalogBooksComponent } from './catalog-books/catalog-books.component';
import { CatalogGenresComponent } from './catalog-genres/catalog-genres.component';
import { BookComponent } from './book/book.component';
import { BookCommentComponent } from './book-comment/book-comment.component';
import { AuthorComponent } from './author/author.component';
import { AuthorCommentComponent } from './author-comment/author-comment.component';
import { AuthorBooksComponent } from './author-books/author-books.component';
import { GenreComponent } from './genre/genre.component';
import { GenreBooksComponent } from './genre-books/genre-books.component';
import { ProfileComponent } from './profile/profile.component';
import { ProfileBooksComponent } from './profile-books/profile-books.component';
import { ProfileBooks1Component } from './profile-books1/profile-books1.component';
import { ProfileBooks2Component } from './profile-books2/profile-books2.component';
import { ProfileBooks3Component } from './profile-books3/profile-books3.component';
import { ProfileBooks4Component } from './profile-books4/profile-books4.component';
import { ProfileBooks5Component } from './profile-books5/profile-books5.component';
import { AdminpanelComponent } from './adminpanel/adminpanel.component';
import { AppRoutingModule } from './app-routing.module';

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatBadgeModule } from '@angular/material/badge';
import { MatMenuModule } from '@angular/material/menu';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { AddBookComponent } from './adminpanel/add-book/add-book.component';
import { AddAuthorComponent } from './adminpanel/add-author/add-author.component';
import { AddGenreComponent } from './adminpanel/add-genre/add-genre.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CarouselComponent,
    MainComponent,
    ListBooksComponent,
    ListAuthorsComponent,
    ListGenresComponent,
    Top100Component,
    CatalogAuthorsComponent,
    CatalogBooksComponent,
    CatalogGenresComponent,
    BookComponent,
    BookCommentComponent,
    AuthorComponent,
    AuthorCommentComponent,
    AuthorBooksComponent,
    GenreComponent,
    GenreBooksComponent,
    ProfileComponent,
    ProfileBooksComponent,
    ProfileBooks1Component,
    ProfileBooks2Component,
    ProfileBooks3Component,
    ProfileBooks4Component,
    ProfileBooks5Component,
    AdminpanelComponent,
    AddBookComponent,
    AddAuthorComponent,
    AddGenreComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,

    MatSliderModule,
    MatToolbarModule,
    MatIconModule,
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatListModule,
    CarouselModule,
    MatTableModule,
    MatBadgeModule,
    MatMenuModule,
    MatChipsModule,
    MatSelectModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
