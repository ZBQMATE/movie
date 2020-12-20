import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'

import { ReactiveFormsModule, FormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GenreComponent } from './genre/genre.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { LoginComponent } from './auth/login/login.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MoviesComponent } from './movies/movies.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GenreComponent,
    HeaderComponent,
    LoginComponent,
    SignUpComponent,
    MoviesComponent,
    MovieCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
